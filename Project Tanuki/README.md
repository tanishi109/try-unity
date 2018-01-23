# project tanuki

Unityによる3Dゲーム習作中のプロジェクトです。  
3つの指を操作してジャンケンしながらフィールドから押し合います。それ以上のルールは未実装です。

# 操作

## メニュー画面

![image](https://user-images.githubusercontent.com/5266152/35257403-5b237e0a-003c-11e8-80bc-7e9a57a72d80.png)

- Click to Start をクリック: ゲームを開始

## ゲーム画面

![image](https://user-images.githubusercontent.com/5266152/35257388-48fa274c-003c-11e8-9bf2-e6ecdac69967.png)

- wasdまたは上下左右キー: 移動
- 123または890キー: 指を伸ばす(後述)
- マウス: カメラを移動
- クリック: クリックした点に移動

### 指の操作について

3つの指の組み合わせによって4種類のジャンケンの手を表現できます。

- グー :punch: : 指を1つも伸ばさない
- チョキ :v: : 指をいずれか2つ伸ばす
- パー :raised_hand_with_fingers_splayed: : 指を3つ伸ばす
- 指差す :point_right: : 指を1つだけ伸ばす。どの手にも勝てませんが、弾かれにくくなります。

