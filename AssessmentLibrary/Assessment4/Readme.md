# Assessment #4

## Problem Statement #1:
Given a list of 10 distinct Urls for 10 identical weather stations placed randomly around London, implement a solution that will request the weather from all 10 weather stations in parallel, returning the fastest response returned without waiting for every response to be fully received.

### Assumptions:
All weather stations are running the same version of the same server side application, and will thus return an identically formed payload, which may look something like this:
```
{
	"lat": 51.531143,
	"long": -0.159893,
	"sampled_at_utc": 1704111329000, 
	"air_temp": 7.51,
	"humidity": 71.0, 
	"pressure_hpa": 1022.0,
	"precipitation": 0.00,
	"wind_kph": 18,
	"wind_direction": 97.0,
}
```

## Problem Statement #2:
Adjust your solution from Problem statment #1 to incude error handling and keep waiting for the first valid response. ie Handle the scenario where the fastest server is only fastest because it returns a Http 500 error on request.

## Problem Statement #3:
Adjust your solution to cleanup incomplete requests in a graceful manner, ie: Once a valid response is returned, the other potentially in-flight requests need to be cleaned up and any associated resources released.

## Problem Statement #3:
Add the ability for your solution to be run periodically eg: every minute. Ensure that a new periodic run does not start if the previous run has not yet completed.