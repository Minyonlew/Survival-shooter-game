# Development of Survival_Shoot_Game(one)

#### 1、创建场景

![01](https://github.com/Minyonlew/Survival-shooter-game/blob/master/Development%20of%20Survival_Shoot_Game(one)/01.png)



#### 2、引入素材包

![02](C:\Users\Minyon\Desktop\gitdemo\First\02.png)



#### 3、将素材包里的Environment预设 拖进 Hierarchy ->加入背景素材。

![03](C:\Users\Minyon\Desktop\gitdemo\First\03.png)



#### 4、将素材包里的Lights预设 拖进 Hierarchy ->加入照亮素材

![04](C:\Users\Minyon\Desktop\gitdemo\First\04.png)



#### 5、- ①选项GameObject->3D Object-> 创建一个Quad（方形平面）

![05A](C:\Users\Minyon\Desktop\gitdemo\First\05A.png)

#### 	

#### - ②设置参数 Position(0,0,0) Rotation(90,0,0) Scale(100,100,1)

- 目的是使这个平面覆盖到整个地板
- 重命名Quad为Floor

![05B](C:\Users\Minyon\Desktop\gitdemo\First\05B.png)



#### - ③通过调整 Mesh Collider -> Remove Component

- 将平面隐藏

![05C](C:\Users\Minyon\Desktop\gitdemo\First\05C.png)



#### - ④接着将 layer->Floor  将其选择为分离层

![05D](C:\Users\Minyon\Desktop\gitdemo\First\05D.png)

#### 6、- ①GameObject -> Create Empty  创建一个新的预设 用来存放背景音乐

![06](C:\Users\Minyon\Desktop\gitdemo\First\06.png)

#### - ②添加一个Component组件Audio Source 来关联背景音乐

![06B](C:\Users\Minyon\Desktop\gitdemo\First\06B.png)

####  - ③添加背景音乐 BackgroundMusic

![06C](C:\Users\Minyon\Desktop\gitdemo\First\06C.png)

#### - ④将音乐设置为loop 循环播放 

![06D](C:\Users\Minyon\Desktop\gitdemo\First\06D.png)



### 至此完成素材的导入，以及初步完成对背景场景的设置。

