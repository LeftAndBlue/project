# 1、简介

这是一个单机的背单词的C#小软件。

# 2、START

1. 将代码拉下来引入需要的包，将报错都给修正过来
2. 启动项目
3. 可以在bin目录下找到exe的启动文件，以后就不用一直启动VS了
4. 创建数据库，可以在app.config里更改成你自己的配置
5. 因为肯定没多少人用，所以没有直接启动的exe文件，只有源码。

# 3、使用

![image-20231119215543134](C:\Users\15975\AppData\Roaming\Typora\typora-user-images\image-20231119215543134.png)

上面就是启动出来的效果，因为是C#想改显示位置的也可以改改。

2. 点击空白处可以进行下一个单词的切换（红框内）

   ![image-20231119215718803](C:\Users\15975\AppData\Roaming\Typora\typora-user-images\image-20231119215718803.png)

3. 因为是单机，而且特别小。就用了文件流进行的单词Id的记录，下次启动可以从背到的地方开始

![image-20231119220347349](C:\Users\15975\AppData\Roaming\Typora\typora-user-images\image-20231119220347349.png)