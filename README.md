# [Bolt into Scripts] 공룡런 게임 만들기

https://www.youtube.com/watch?v=ktm-hvm6r8s

![image](https://user-images.githubusercontent.com/50513500/151666104-d59b56bd-6745-453d-a0e8-27e078e0b806.png)


### 제작목적
* 이번 프로젝트의 목적은 스크립트가 없이 볼트로 제작된 유니티 프로젝트를 스크립트를 사용해서 똑같이 구현하는 것 입니다.


### 3.장애물 만들기
![Dino Run 3](https://user-images.githubusercontent.com/50513500/152314304-e6acbdd3-7bff-4153-b713-92d237a6955c.gif)

##### 구현
* 장애물 [선인장]을 추가.
* 랜덤으로 장애물 [선인장]이 등장.
* 선인장에 부딫힐 시 Die상태로 변하며, 애니메이션과 사운드 재생.
* Die상태에서 점프 동작 및 LandSound 작동불가.

### 4.점수 구현하기
![Dino Run 4](https://user-images.githubusercontent.com/50513500/152541399-925b73fc-a666-4d0f-9d02-8d10fdd0dc8c.gif)

##### 구현
* deltaTime을 사용해 시간을 계산해서 점수로 사용.
* 점수와 텍스트 UI연결. 실시간으로 점수 표시(4자리까지 나타내고 숫자가 없는 곳은 0으로 표시)
* 10점이 될 때마다 확대효과로 포인트를 준 애니메이션을 텍스트UI에 적용.
