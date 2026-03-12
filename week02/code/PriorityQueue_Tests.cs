using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities.
    // Expected Result: Dequeue should return the item with the highest priority.
    // Defect(s) Found: The original code did not always examine the last item in the queue, so the highest-priority item could be missed.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: Dequeue should return the first item added among the tied highest-priority items (FIFO behavior).
    // Defect(s) Found: The original code used >= when comparing priorities, which caused the last tied item to be selected instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: No defect found in this area; the empty queue exception was already implemented correctly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Dequeue an item, then check the queue contents.
    // Expected Result: The removed highest-priority item should no longer be in the queue.
    // Defect(s) Found: The original code returned the highest-priority value but did not actually remove it from the queue.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
        Assert.AreEqual("[Low (Pri:1), Medium (Pri:5)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue multiple times from a queue with multiple priorities.
    // Expected Result: Items should be removed in priority order across multiple dequeues.
    // Defect(s) Found: Because the original code did not remove dequeued items, repeated calls could return incorrect repeated results.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}