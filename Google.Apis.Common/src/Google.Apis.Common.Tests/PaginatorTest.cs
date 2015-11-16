﻿// Copyright 2015 Google Inc. All Rights Reserved.
// Licensed under the Apache License Version 2.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Google.Apis.Common.Tests
{
    public class PaginatorTest
    {
        private static readonly PaginatedResource s_simpleResource = new PaginatedResource(
            nameof(s_simpleResource),
            new Page("x", 1, 2, 3),
            new Page("y", 4, 5),
            new Page(null, 6, 7));

        private static readonly PaginatedResource s_resourceWithEmptyPages = new PaginatedResource(
            nameof(s_resourceWithEmptyPages),
            new Page("a", 1, 2, 3),
            new Page("b"),
            new Page("c"),
            new Page("d", 4, 5),
            new Page(null));

        private static readonly PaginatedResource s_requestCheckingResource = new PaginatedResource(
            nameof(s_requestCheckingResource),
            new Page("x", 1, 2, 3),
            new Page(null, 4, 5))
        {
            RequestCheck = "foo"
        };
        
        public static object[] AllResources { get; } = { new object[] { s_simpleResource }, new object[] { s_resourceWithEmptyPages }, new object[] { s_requestCheckingResource } };

        [Theory, MemberData(nameof(AllResources))]
        public void Fetch(PaginatedResource resource)
        {
            var actual = PaginatedResource.Paginator.Fetch(new Request { Check = resource.RequestCheck }, resource.GetPage);
            Assert.Equal(resource.AllItems, actual);
        }

        [Theory, MemberData(nameof(AllResources))]
        public async Task FetchAsync(PaginatedResource resource)
        {
            var asyncSequence = PaginatedResource.Paginator.FetchAsync(new Request { Check = resource.RequestCheck }, resource.GetPageAsync);
            var actual = await asyncSequence.ToList();
            Assert.Equal(resource.AllItems, actual);
        }

        [Theory, MemberData(nameof(AllResources))]
        public async Task FetchAllAsync(PaginatedResource resource)
        {
            var actual = await PaginatedResource.Paginator.FetchAllAsync(new Request { Check = resource.RequestCheck }, resource.GetPageAsync);
            Assert.Equal(resource.AllItems, actual);
        }

        [Fact]
        public async Task Cancellation()
        {
            var cts = new CancellationTokenSource();
            var resource = s_simpleResource;
            var actual = PaginatedResource.Paginator.FetchAsync(new Request { Check = resource.RequestCheck }, resource.GetPageAsync);
            var iterator = actual.GetEnumerator();
            Assert.True(await iterator.MoveNext(cts.Token));
            cts.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await iterator.MoveNext(cts.Token));
        }

        // Has to be public so we can use it as a parameter for test cases
        public class PaginatedResource
        {
            internal static readonly Paginator<int, Request, Page, string> Paginator =
                new Paginator<int, Request, Page, string>(
                    (request, token) => new Request { Check = request.Check, Token = token },
                    page => page.NextPageToken,
                    page => page.Items,
                    null);

            internal List<Page> Pages { get; } = new List<Page>();
            internal string Name { get; set; }
            internal string RequestCheck { get; set; }

            internal PaginatedResource(string name, params Page[] pages)
            {
                this.Name = name;
                this.Pages = pages.ToList();
            }

            public override string ToString()
            {
                return Name;
            }

            internal Page GetPage(Request request)
            {
                Assert.Equal(RequestCheck, request.Check);
                int index = Pages.FindIndex(page => page.NextPageToken == request.Token);
                // A request for the first page will have the NextPageToken of the last page... so we should always
                // find something.
                Assert.NotEqual(-1, index);
                index = (index + 1) % Pages.Count;
                return Pages[index];
            }

            internal async Task<Page> GetPageAsync(Request request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Yield();
                return GetPage(request);
            }

            public IEnumerable<int> AllItems => Pages.SelectMany(page => page.Items);
        }

        internal class Request
        {
            internal string Token { get; set; }
            // Used to check that we keep the right request info
            internal string Check { get; set; }
        }

        internal class Page
        {
            internal List<int> Items { get; }
            internal string NextPageToken { get; }

            internal Page(string token, params int[] items)
            {
                this.NextPageToken = token;
                this.Items = items.ToList();
            }
        }
    }
}
