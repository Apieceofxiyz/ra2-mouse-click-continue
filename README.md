# Ra2定制版鼠标连点器-continued

本项目基于树牌连点器改写，源项目地址为：

https://gitee.com/lenchu/ra2-mouse-click

本项目地址为：
https://github.com/Apieceofxiyz/ra2-mouse-click-continue

#### 功能亮点简介

1. 不影响游戏自身快捷键的使用
	- 连点热键默认左 shift 键，同时不影响使用左 shift 键多选单位
2. 连点热键与连点次数与连点间隔均可自由配置
	- 点击修改配置按钮，即可打开配置文件，大部分配置项均已用中文写了注释，方便使用者快速理解
3. 自动探测模式
	- 自动探测进入游戏开启连点，结束游戏关闭连点
4. 辅助编队
	- 辅助编队是 TC 版特有功能，与主版本分别发布
	- 原理是按键映射，例如把 E 键映射到数字8，那么按 Ctrl E 即可编小队8，按E即可选中小队8，同时建造栏切换到步兵栏
	- 把 R 键映射到数字9同理
	- 映射规则可自由配置，配置文件在 TC 版 plugins 目录下的 KeyMappings.txt 文件
5. 支持识别Ares环境（自0.5版本起）
	- 在识别到Ares环境时避免与Ares自带连点冲突（此时仅可连点5的整数倍）

#### 安装使用说明

- 下载发行版的 zip 压缩包，解压即用

