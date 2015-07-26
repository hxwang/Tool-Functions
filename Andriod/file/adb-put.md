### adb put

### Execute Eclipse
```
Huangxins-MacBook-Pro:eclipse huangxinwang$ find . -name eclipse
./Eclipse.app/Contents/MacOS/eclipse
Huangxins-MacBook-Pro:eclipse huangxinwang$ cd Eclipse.app/Contents/MacOS/
Huangxins-MacBook-Pro:MacOS huangxinwang$ ls
eclipse		eclipse.ini
Huangxins-MacBook-Pro:MacOS huangxinwang$ ./eclipse &

```

### adb and push file to android system
```
Huangxins-MacBook-Pro:adt-bundle-mac-x86_64 huangxinwang$ cd sdk
Huangxins-MacBook-Pro:sdk huangxinwang$ ls
add-ons		platform-tools	system-images
extras		platforms	tools
Huangxins-MacBook-Pro:sdk huangxinwang$ cd platform-tools/
Huangxins-MacBook-Pro:platform-tools huangxinwang$ ls
NOTICE.txt		api			lib
aapt			dexdump			llvm-rs-cc
adb			dx			renderscript
aidl			fastboot		source.properties
Huangxins-MacBook-Pro:platform-tools huangxinwang$ ./adb shell
root@android:/ # mount
rootfs on / type rootfs (ro,relatime)
tmpfs on /dev type tmpfs (rw,nosuid,relatime,mode=755)
devpts on /dev/pts type devpts (rw,relatime,mode=600)
proc on /proc type proc (rw,relatime)
sysfs on /sys type sysfs (rw,relatime)
none on /acct type cgroup (rw,relatime,cpuacct)
tmpfs on /mnt/asec type tmpfs (rw,relatime,mode=755,gid=1000)
tmpfs on /mnt/obb type tmpfs (rw,relatime,mode=755,gid=1000)
none on /dev/cpuctl type cgroup (rw,relatime,cpu)
/dev/block/mtdblock3 on /system type yaffs2 (ro,relatime)
/dev/block/mtdblock5 on /data type yaffs2 (rw,nosuid,nodev,relatime)
/dev/block/mtdblock4 on /cache type yaffs2 (rw,nosuid,nodev,relatime)
/sys/kernel/debug on /sys/kernel/debug type debugfs (rw,relatime)
/dev/block/vold/179:1 on /storage/sdcard0 type vfat (rw,dirsync,nosuid,nodev,noexec,relatime,uid=1000,gid=1015,fmask=0702,dmask=0702,allow_utime=0020,codepage=cp437,iocharset=iso8859-1,shortname=mixed,utf8,errors=remount-ro)
/dev/block/vold/179:1 on /mnt/secure/asec type vfat (rw,dirsync,nosuid,nodev,noexec,relatime,uid=1000,gid=1015,fmask=0702,dmask=0702,allow_utime=0020,codepage=cp437,iocharset=iso8859-1,shortname=mixed,utf8,errors=remount-ro)
tmpfs on /storage/sdcard0/.android_secure type tmpfs (ro,relatime,size=0k,mode=000)
root@android:/ # exit
Huangxins-MacBook-Pro:platform-tools huangxinwang$ ./adb remount
remount succeeded
Huangxins-MacBook-Pro:platform-tools huangxinwang$ export PATH=$PWD:$PATH

Huangxins-MacBook-Pro:binaries huangxinwang$ ls
fill	read2	replay
Huangxins-MacBook-Pro:binaries huangxinwang$ adb push fill /system/bin
192 KB/s (5484 bytes in 0.027s)
Huangxins-MacBook-Pro:binaries huangxinwang$ adb push read2 /system/bin
136 KB/s (5516 bytes in 0.039s)

Huangxins-MacBook-Pro:binaries huangxinwang$ adb shell
root@android:/ # busybox chmod 75555 /system/bin/
chmod: invalid mode '75555'
1|root@android:/ # busybox chmod 7555 /system/bin/                             
root@android:/ #

### adb logcat
记录手机上的所有操作
