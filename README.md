# PoissonDiscSamplingAlgorithm
A static helper-class implementation of the Poisson Disc Sampling algorithm, based on this video by Sebastian Lague: https://www.youtube.com/watch?v=7WcmyxyFO7o.

Visual example of the algorithm in action:
![PDS visual example](/images/poisson-disc-sampling-experiment.png)

The static helper-method for getting a list of Vector2 positions. Parameters are as follows:
* The placement radius of a position
* The region size, the size of the sampling area
* The amount of times to try and sample a specific position within the sampling area before aborting and attempting with a newly generated position
![PDS Static Helper-Method](/images/PoissonSampler-SamplePoissonDiscPositions.png)
