## Write Module

```
1.写到/sys文件夹下
    内核module写到 /sys 下的文件下，用户空间才能使用
    因为用户空间不能直接接触到内核空间
2. lsmod 查看模块
 Insmod把模块插入到内核当中
3. .c文件
    用make后，生成ko文件，然后insert到内核当中
4. 内核的文件都在kernel中
```
