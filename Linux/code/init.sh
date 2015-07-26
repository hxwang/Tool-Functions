#!/bin/bash

DIR="/sys/fs/cgroup/cpuacct"

if ! [ -d $DIR ];then
    mount -t tmpfs cgroup_root /sys/fs/cgroup
    mkdir /sys/fs/cgroup/cpuacct
    mkdir /sys/fs/cgroup/freezer
    mount -t cgroup -ocpuacct cpuacct /sys/fs/cgroup/cpuacct
    mount -t cgroup -ofreezer freezer /sys/fs/cgroup/freezer
else
    echo "dir exists already!"
fi
