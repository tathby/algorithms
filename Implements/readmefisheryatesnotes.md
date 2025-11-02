# fisher-yates
## the original fisher yates shuffle was invented before computers 
it ran on O(n^2) time comeplexity and O(n) space complexity
this was not optimal for computers so the new fisher yates shuffle was invented which ran on linear time
the new shuffle focuses on shuffling the items in place, an operation which runs on O(1) time complexity
you do this n number of times as you decrememnt and swap through the aray for a time complexity of O(n)
I prefer the new fifsher yates shuffle as I appreciate it's sleek solution to the problem of randomizing elements, it is much morer sensible to me as a programmer
One change i might make is insuring there is a copy of the original, unshuffled version of the list in case you need to compare the two, for example if you're testing how well your algorithm actually shuffled the data.
