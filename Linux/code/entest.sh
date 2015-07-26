#!/bin/bash

echo mylock > /sys/power/wake_lock
# 245000 384000 422400 460800 499200 537600 576000 614400 652800 691200 729600 768000 806400 844800 883200 921600 960000 998400 1036800 1075200 1113600
# 245000 384000 422400 460800 499200 537600 576000 
# for FREQ in 245000 422400 537600 652800 768000 883200 998400 1113600
for FREQ in 691200 729600 768000 806400 844800 883200 921600 960000 998400 1036800 1075200 1113600
do
    echo $FREQ > /sys/devices/system/cpu/cpu0/cpufreq/scaling_min_freq
    cat /sys/devices/system/cpu/cpu0/cpufreq/scaling_cur_freq >> /data/testresult
    for PERC in 30 40 50 60 70 80 90 
    do
   echo $PERC
	/data/loop 1 0 2000 &
	MPID=$!
	echo "$!, $PERC" > /data/config
	wait $MPID
    done
done

echo mylock > /sys/power/wake_unlock
