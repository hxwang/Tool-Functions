## Time

`rdtsc` can not be used in arm architecture

`clock_gettime(CLOCK_MONOTONIC, &start); //precision: nanoseconds`

eg:
```
 struct timespec start, end;
 long interval, ns_diff;
 clock_gettime(CLOCK_MONOTONIC, &start);
 clock_gettime(CLOCK_MONOTONIC, &end);

 interval = end.tv_sec - start.tv_sec;
   
 ns_diff = end.tv_nsec - start.tv_nsec;
```
