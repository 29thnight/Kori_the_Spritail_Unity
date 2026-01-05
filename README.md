# Kori the Spritail – Nintendo Switch Port

**Kori the Spritail**은 정령 도마뱀 *코리(Kori)*와 함께 모험을 떠나는  
**2인 로컬 멀티플레이 액션 어드벤처 게임**입니다.

본 저장소는 **Nintendo Switch 플랫폼 포팅 작업을 위한 Unity 프로젝트**를 관리합니다.

---

## Game Overview

- **Genre**: 2-Player Local Co-op Action Adventure  
- **Players**: 2 (Local Multiplayer)  
- **Platforms**: Nintendo Switch (Primary), PC  
- **Engine**: Unity  
- **Input**: Gamepad (Joy-Con / Pro Controller)

게임은 전투와 탐험 중심의 액션으로 구성되어 있으며,  
퍼즐이나 환경 기믹 없이 **협력 플레이 자체의 재미**에 집중합니다.

플레이어는 서로 다른 역할을 가진 두 캐릭터를 조작하며,  
공격과 지원을 분담해 전투를 진행합니다.

---

## Repository Purpose

이 저장소는 다음 목적을 가집니다.

- Nintendo Switch 플랫폼 대응을 위한 **Unity 프로젝트 관리**
- 콘솔 환경에 맞춘 **성능 최적화 및 입력 대응**
- 빌드 설정, 플랫폼별 이슈, 포팅 과정 기록

> ⚠️ 본 저장소는 **Switch 포팅 작업용**이며,  
> 일부 기능은 PC 버전과 동작이 다를 수 있습니다.

---

## Development Environment

- **Unity Version**: 2022 LTS (Switch 지원 버전)
- **Target Platform**: Nintendo Switch
- **OS**: Windows 10 / 11
- **Version Control**: Git

---

## Build & Run (Nintendo Switch)

> ⚠️ Nintendo Switch 빌드는 **Nintendo 승인 개발 환경**이 필요합니다.

1. Unity Hub에서 프로젝트 열기
2. `File > Build Settings`
3. Platform을 **Nintendo Switch**로 변경
4. 필요한 Player Settings 확인
   - Resolution / Performance
   - Input System 설정
5. `Build` 또는 `Build And Run`

---

## Controls

- **Player 1 / Player 2**
  - Left Stick: Move
  - Action Button: Attack / Interaction
  - Support Button: Kori Ability / Assist Action

(최종 버튼 매핑은 플랫폼별로 조정될 수 있습니다.)

---

## Project Structure

```text
Assets/
 ├─ Scripts/          # Gameplay / System Scripts
 ├─ Scenes/           # Game Scenes
 ├─ Prefabs/          # Characters / Enemies / Objects
 ├─ UI/               # HUD / In-Game UI
 ├─ Art/              # Models / Textures / Effects
 └─ Settings/         # Platform / Input / Build Settings
Notes for Switch Porting
퍼포먼스 안정화를 위해 프레임 드롭 방지를 우선 고려

불필요한 Editor 전용 패키지 제거

메모리 사용량 및 로딩 타이밍 주의

로컬 멀티플레이 입력 충돌 여부 지속 확인

Known Issues
일부 이펙트는 Switch 성능 한계로 인해 품질이 조정될 수 있음

Joy-Con 분리/결합 상태에 따른 입력 처리 개선 필요

특정 씬에서 로딩 지연 발생 가능

License
This project is proprietary and confidential.
Unauthorized distribution or commercial use is not permitted.
