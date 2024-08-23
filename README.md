## PingPong AR advanced 개요   

### 1. 왜 개발하려고?
서울시에서 주관하는 `SeSAC 서대문캠퍼스 청년취업사관학교`에서 수강한 `Unity와 로블록스를 통한 메타버스 게임 제작 과정`에서 최종 프로젝트로 [PingPong AR](https://github.com/cheona-thousand-man/Pingpong-AR)을 기획하고 개발하였지만, 새로운 SDK를 적용하면서 생긴 어려움에 어정쩡하게 끝나고 말았다. 
- `Photon Fusion2`에 대한 사용자들의 사용 후기/예제 미흡
- Fusion2만의 `Shared Mode`에 대한 이해 난이도 높음
- 다만 2.5주 프로젝트에서 1.5주를 갈아넣고서야 겨우내 겉핥기로 이해가 되었고, 네트워킹 작동은 어찌저찌 구현 완료
> **시간 부족으로 미완성 상태로 끝난 프로젝트를 완성하고, Google Paly Store에 앱 퍼블리싱 하고 싶다!!**

### 2. 구현 목표
- **탁구대 생성**
  - [1단계] 이미지 마커 기반 탁구대 생성
  - [2단계] 상대방과 본인 거리 가운데 탁구대 생성
- **게임 대기방**
  - [1단계] 탁구는 1:1이지만, 한 게임에서 여러명이 접속할 경우 방을 여러개 만들어서 플레이 가능하게
  - [2단계] AI와의 대전 기능 추가
- **색다른 게임 조작**
  - [1단계] 휴대폰으로 날아오는 공을 보고, 공 앞에서 폰을 휘두를 때의 `자이로센서` `가속도센서`로 타격 구현
    - 센서값에 따른 타격 각도/속도 지정
    - +α 공에 맞을 때 휴대폰 진동/시각 효과로 재미 요소 가미
  - [2단계] 탁구대 위에 무작위 효과 `Spot` 을 생성하여 랜덤요소 가미
    - 1단계가 노템전이면, 2단계는 템전
- **UI 최적화**
  - 개발자의 UI 디자인 수준은 참혹하다(...)
  - 1단계가 구현된다면, UI 디자이너 섭외해서 UI 다듬을 예정

### 3. 구현 일정
- **4주 내에 개발 목표** `24.08.21`부터 `24.00.00`까지
- **Develop History**
  - [24.08.21] `PingPong AR Advanced` 레퍼지토리 생성, `README.md` 작성
  - [24.08.23-] [게임 구상](https://drive.google.com/file/d/1ZpD8NNa2ulFVfyKfDmFfAqkoy2hpzPnF/view?usp=sharing)
    - **Step1** `PingPong` 탁구대/탁구공/탁구채 상호작용
    - **Step2** `Game Logic` 선 결정, 점수 획득, 서브 교체, 게임 승리 
    - **Step3** `Network Logic` 네트워크 1대1 접속, 게임 방 생성/접속, GameObject 네트워킹
    - **Step4** `Swing by Sensor` 스마트폰 센서로 탁구공 타격
    - **Step5** `AI` 인공지능 대전
    - **Step6** `Hit Effect & Fun` 공 타격 효과, 랜덤 효과 적용 아이템
    - **Step7** `UI` 맛깔나게 꾸며보쟈