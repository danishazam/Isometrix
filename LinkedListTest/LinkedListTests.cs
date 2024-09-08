using System;
using Xunit;
using System.IO;
using System.Text;
using LinkedList;

namespace LinkedListTest
{
    public class LinkedListTests
    {
        private LinkedList.LinkedList<int> list;

        public LinkedListTests()
        {
            list = new LinkedList.LinkedList<int>();
        }

        [Fact]
        public void Insert_Should_InsertNodeAtBeginning()
        {
            // Act
            list.Insert(10, 0);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("10 -> null\r\n", output);
        }

        [Fact]
        public void Insert_Should_InsertNodeAtMiddle()
        {
            // Arrange
            list.Insert(10, 0);
            list.Insert(20, 1);

            // Act
            list.Insert(15, 1);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("10 -> 15 -> 20 -> null\r\n", output);
        }

        [Fact]
        public void Insert_Should_InsertNodeAtEnd()
        {
            // Arrange
            list.Insert(10, 0);
            list.Insert(20, 1);

            // Act
            list.Insert(30, 2);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("10 -> 20 -> 30 -> null\r\n", output);
        }

        [Fact]
        public void Insert_Should_ThrowException_WhenPositionOutOfRange()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(10, 1));
            Assert.Equal("Cannot insert at non-zero position in an empty list (Parameter 'position')", ex.Message);
        }

        [Fact]
        public void Delete_Should_DeleteNodeAtBeginning()
        {
            // Arrange
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.Insert(30, 2);

            // Act
            list.Delete(0);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("20 -> 30 -> null\r\n", output);
        }

        [Fact]
        public void Delete_Should_DeleteNodeAtMiddle()
        {
            // Arrange
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.Insert(30, 2);

            // Act
            list.Delete(1);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("10 -> 30 -> null\r\n", output);
        }

        [Fact]
        public void Delete_Should_DeleteNodeAtEnd()
        {
            // Arrange
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.Insert(30, 2);

            // Act
            list.Delete(2);

            // Assert
            var output = CaptureOutput(() => list.PrintList());
            Assert.Equal("10 -> 20 -> null\r\n", output);
        }

        [Fact]
        public void Delete_Should_ThrowException_WhenPositionOutOfRange()
        {
            // Arrange
            list.Insert(10, 0);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(1));
            Assert.Equal("Position exceeds list length (Parameter 'position')", ex.Message);
        }

        [Fact]
        public void Delete_Should_ThrowException_WhenListIsEmpty()
        {
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => list.Delete(0));
            Assert.Equal("List is empty", ex.Message);
        }

        [Fact]
        public void PrintList_Should_PrintEmptyListMessage_WhenListIsEmpty()
        {
            // Act
            var output = CaptureOutput(() => list.PrintList());

            // Assert
            Assert.Equal("List is empty\r\n", output);
        }

        [Fact]
        public void Insert_Should_ThrowException_WhenPositionIsNegative()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(10, -1));
            Assert.Equal("Position cannot be negative (Parameter 'position')", ex.Message);
        }

        [Fact]
        public void Delete_Should_ThrowException_WhenPositionIsNegative()
        {
            // Arrange
            list.Insert(10, 0);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(-1));
            Assert.Equal("Position cannot be negative (Parameter 'position')", ex.Message);
        }

        // Helper method to capture console output
        private string CaptureOutput(Action action)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action();
                return sw.ToString();
            }
        }
    }

}

