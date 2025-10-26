# Data Structure Comparison: Arrays, Maps, Stacks, and Queues

## Array vs. Map

### How They Work
- **Array:**  
  A fixed-size, ordered collection of elements that are indexed.    
- **Map (Dictionary/Hash Table):**  
  A collection of key-value pairs. Each key maps to a value, allowing fast lookups.  

### Key Differences

Access method: By index, By key/hash
Data order: Sequential, By key/hash
Duplicates: Allowed, Keys must be unique
Resizing: Fixed, Dynamic

### Efficiency
- Arrays are more memory-efficient and faster for sequential access and iteration.  
- Maps are better for fast lookups, searching, and associative relationships.

---

## Stack vs. Queue

### How They Work
- **Stack (LIFO):**  
  Last-In, First-Out — items are added and removed from the top.  
- **Queue (FIFO):**  
  First-In, First-Out — items are added to the end and removed from the front.  

### Key Differences

Order: Last-In First-Out, First-In First-Out
Primary Operations: Push / Pop, Enqueue / Dequeue
Common Uses: Undo/Redo & Backtracking, Task scheduling & Message handling

### Efficiency
Both structures have O(1) time complexity for adding and removing elements, but:
- Stacks are more efficient when you only need to work with the most recent item.
- Queues are better when processing items in the order they arrive.


