﻿#region license
// Copyright (c) 2007-2009 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using MbUnit.Framework;
using SolrNet.Exceptions;

namespace SolrNet.Tests {
	[TestFixture]
	public class SortOrderTests {
		[Test]
		[ExpectedException(typeof (InvalidSortOrderException))]
		public void Constructor_ShouldntAcceptSpaces() {
			var o = new SortOrder("uno dos");
		}

		[Test]
		public void DefaultOrder() {
			var o = new SortOrder("uno");
			Assert.AreEqual("uno asc", o.ToString());
		}

		[Test]
		public void ParseNull_ShouldReturnNull() {
			var o = SortOrder.Parse(null);
            Assert.IsNull(o);
		}

        [Test]
        public void ParseEmpty_ShouldReturnNull() {
            var o = SortOrder.Parse("");
            Assert.IsNull(o);
        }

		[Test]
		public void Parse() {
			var o = SortOrder.Parse("pepe");
			Assert.AreEqual("pepe asc", o.ToString());
		}

		[Test]
		public void ParseAsc() {
			var o = SortOrder.Parse("pepe asc");
            Assert.Like(o.ToString(), "pepe asc");
		}

		[Test]
		public void ParseDesc() {
			var o = SortOrder.Parse("pepe desc");
            Assert.Like(o.ToString(), "pepe desc");
		}

        [Test]
        public void ParseDescWithSpaces() {
            var o = SortOrder.Parse("pepe  desc");
            Assert.Like(o.ToString(), "pepe desc");
        }

		[Test]
		[ExpectedException(typeof (InvalidSortOrderException))]
		public void InvalidParse_ShouldThrow() {
			var o = SortOrder.Parse("pepe bla");
		}
	}
}