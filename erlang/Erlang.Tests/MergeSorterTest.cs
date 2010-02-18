using NUnit.Framework;

namespace Erlang.Tests {
    [TestFixture]
    public class MergeSorterTest {
        [Test]
        public void ShouldMerge2ItemsAscendings() {
            Assert.That(MergeSorter.Merge(new[] {2}, new[] {1}), Is.EqualTo(new[] {1, 2}));
        }

        [Test]
        public void ShouldMergeDifferentSizedArrays() {
            Assert.That(MergeSorter.Merge(new[] {2}, new[] {1, 3}), Is.EqualTo(new[] {1, 2, 3}));
        }

        [Test]
        public void ShouldMergeArraysWithEqualEntries() {
            Assert.That(MergeSorter.Merge(new[] {1, 3, 5}, new[] {1, 2, 3}), Is.EqualTo(new[] {1, 1, 2, 3, 3, 5}));
        }
    }
}