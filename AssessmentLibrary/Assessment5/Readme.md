# Assessment #5

## Problem Statement #1:
Implement a Pub/Sub setup within a **SINGLE APPLICATION** whereby distinct Publisher + Subscriber instances are running simultaneously and the consumption of published values is fully decoupled from the publisher. The publisher should produce values at a rate of between 2hz and 10hz. 

## Problem Statement #2:
Demonstrate that your Pub/Sub setup is fully decoupled by running the subscriber slower than the rate of value production (eg @1hz).

## Problem Statement #3:
Add a second/multiple subscriber(s) that run in parallel with and decoupled from the first subscriber. Ensure there are no thread safety / concurrency issues between subscribers.

## Problem Statement #4:
Add the ability for the Publisher to signal subscribers when there are no more values to be published so that once all in-flight messages have been consumed subscribers can safely be stopped / shutdown / disposed.

## Problem Statement #5:
Add the ability for slow consumption to apply back-pressure on the publisher to effectively throttle production.
