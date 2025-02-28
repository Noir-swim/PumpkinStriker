# 🎃PumpkinStriker🎃

**PumpkinStriker** は、かぼちゃにボールを当てることで、楽しく3D空間の操作と放物運動の仕組みを学べるゲームです。小学生でも直感的に操作でき、ボールの初速や角度の違いを通して、物理的な概念（放物運動や3D空間認識）を遊びながら養うことができます。

---

## ゲーム概要🎮

- **ゲームコンセプト**  
  プレイヤーは大砲から発射されるボールを操作し、かぼちゃ（Cube）に当てることでスコアを獲得します。ボールはプレイヤーが入力した **x, y, z** の値に基づき、放物運動に従って飛行します。

- **教育的アプローチ**  
  このゲームは、3D空間でのボールの軌道を観察しながら、直感的に物理法則（特に初速や角度の関係）を理解できるように設計しています。

---

## 主な特徴と実装の工夫⚙️

### 1. ボールの操作と軌道描画
- **SphereController.cs**  
  - プレイヤーの入力（x, y, z）に基づき、ボールに**インパルス（ボールの初速度とする）**を加えて発射します。  
  - 発射後、**LineRenderer** を使用してボールの軌道をリアルタイムに描画し、飛行経路を視覚的に確認できるようにしました。
  - 画面外に出た場合や Cube との衝突時に、自動でボールをリスポーンする処理を実装しました。

### 2. 衝突時のオブジェクトの制御
- **Destroy.cs**  
  - 衝突したオブジェクトのアクティブ状態を切り替えることで、Cube を消去（または非表示）する処理を実装。

### 3. ゲーム進行とシーン切り替え
- **CubeManager.cs**  
  - シーン内の Cube の状態を監視し、すべてが破壊された場合に、一定の遅延後に次のシーン（IllustScene）に自動切り替えをしました。
  - ゲームのリトライ機能も実装し、別のシーン（HeardScene）に遷移可能に設定しました。
  
- **ReturnToStart.cs** および **LoadGameScene.cs**  
  - タイトルシーンや各種難易度シーンへの遷移を制御。UI のホームボタンから簡単にシーン間の移動ができるように工夫しました。

### 4. カメラ視点の切り替え
- **CameraManager.cs**  
  - 2つのカメラ間で視点を切り替える機能を実装しました。  
  - ゲーム中の状況に応じた最適な視点をプレイヤーに提供しました。

### 5. タイマー機能
- **TimeCounter.cs**  
  - ゲーム開始後、カウントダウンタイマーを表示し、時間切れになると Game Over の表示と処理を行いました。
  - ゲームの進行状況を時間で制御することで、プレイヤーに時間内のチャレンジ感を提供しました。

### 6. リスポーン処理
- **RespawnController.cs**  
  - UIボタンと連携し、ボールが画面外に出た場合に、新たなボールを生成するリスポーン処理を実装しました。

---

## ゲーム開発工程の様子👀📕
プロジェクトの詳細やビジュアルなどの説明は、以下のURLをご参照ください。

https://mcm-www.jwu.ac.jp/~physm/buturi24/game/index.html
---
