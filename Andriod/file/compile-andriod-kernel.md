## Compile Android Kernel

- credit for Mengbai


因为模块和内核有匹配问题，因此只有和内核版本相对应的模块才能动态的插入到系统中（当然你可以内核强制链接任意版本的模块，但是这个特性需要重新编译内核才能打开）

遗憾的是我们得到的手机上运行的内核(cm-kernel)找不到对应的代码树来帮助我们编译模块。事实上是cm-kernel的内核在编译完成后会出现黑屏的问题。我们需要用evervolv版本的kernel来替换。

### Step 1:
下载内核代码树和对应的rom：
```
$ mkdir -p ~/source/android/kernel/
$ cd ~/source/android/kernel/
$ git clone https://github.com/Evervolv/android_kernel_htc_qsd8k.git
```
下载rom的网址：http://forum.xda-developers.com/showthread.php?p=24542016#post24542016
我下载的是alpha版本

### Step 2:
烧写你所下到的＊.zip文件， 并从＊.zip文件中解压出boot.img文件备用
Note: By compling linux kernel, we will get zImage, then we use boottools to combine zImage+randisk into boot.img, use this boot.img to replace the one in the zip file. Then the zip file can be install in android by recovery mode. Or we can simply use fastboot boot boot.img to flash it into android.


### Step 3:
编译内核
```
$ cd ~/source/android/kernel/android_kernel_htc_qsd8k
```
//连上手机
```
$ adb pull /proc/config.gz .
$ zcat config.gz > .config
$ export ARCH=arm
$ export PATH=$PATH:${DIR_YOU_PUT_YOUR_CROSS_COMPILER_TOOLS}
```
//这里的$CROSS_COMPILE的前缀我没有使用的ndk中的arm-linux-androideabi-， 而是使用
//的是android源码树中的prebuilt/linux-x86/toolchain/arm-eabi-4.4.3/bin/中的交叉编译工具，
//事实上我没有发现在编译内核时有什么区别，但是在编译module时使用ndk的工具可能会导致
//模块无法下载。在编译内核和模块时尽量保证两个编译工具一致
```
$ export CROSS_COMPILE=arm-eabi-
$ make -j10
Note: Here .config may not work, and will have error XXX is undefied
I use mengbai's config
```

### Step 4:
制作新的boot.img
解包boot.img的工具见附件
```
$ cd ~/source/kernel/
$ tar xfz boottools.tar.gz
$ cd boottools
//这里的boot.img来自Step 2
$ cp ${SOMEWHERE}/boot.img .
$ ./extract.sh
```
//有用的信息都在新出现的unpack目录下, 旧的zImage已经被移走了
```
$ cat unpack/boot.img-base unpack/boot.img-cmdline unpack/boot.img-pagesize
20000000
no_console_suspend=1 msmsdcc_sdioirq=1 wire.search_count=5
2048
```
//下面重新打包boot.img, mkbootimg在android的源码中可以找到，位置
//是out/host/linux-x86/bin/mkbootimg
```
$ mkbootimg --kernel ../android_kernel_htc_qsd8k/arch/arm/boot/zImage --ramdisk unpack/boot.img-ramdisk.gz --cmdline unpack/boot.img-cmdline --base 20000000 --pagesize 2048 -o newboot.img
Note: use ./mkbooting XXX
```

成功的话当前目录就有新的newboot.img了！
ps: rahul之前提到的命令
$ fastboot boot zImage
会让手机无法启动，只有烧写boot.img才能让手机成功启动

ps2: 使用fastboot的只能暂时的烧写你的内核，永久改变的话可以把boot.img替换到前面的zip中
ps3: 我没有试过ps2
Note: use the follow command
adb reboot bootloader //let the phone enter fastboot mode
fastboot boot boot.img //flash this to the phone
But since the other components may not be compatible with boot.img, in this case we need to use recovery to flash the OS forever
xi@xi:~/test$ adb push mengbai.zip ./sdcard
failed to copy 'mengbai.zip' to './sdcard': Is a directory
xi@xi:~/test$ adb push mengbai.zip ./sdcard/mengbai.zip

Error: unvefication zip
Solution:You can turn off signature verification in Clockwork. That should fix it. I believe its under install zip from SD. Then instead of going to choose zip, select toggle signature verification

### Steop 5:
编译内核模块
向平常一样编译就好，记得指定内核代码树：

```
$ pwd
${YOUR_KERNEL_MODULE_DIR}
$ cat Makefile
…
KERNELDIR ?= ~/source/android/kernel/android_kernel_htc_qsd8k
…
```
好了，现在可以成功运行insmod了

```
# insmod /sdcard/hello.ko
# dmesg
…
<1>[   89.407867] Hello, World!
…
```
