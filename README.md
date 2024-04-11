# IngameConsoleView-R3-TMP

IngameConsole System https://github.com/sh-kj/Unity-IngameConsole.git  
の、R3 versionをuGUI/TextMeshProで実装したViewです。

## 主な機能

- コンソールとデバッグコマンド、ボタンによるデバッグコマンドのショートカット
- uGUI+TextMeshProによるコンソールの実装
- フレームレート表示とコンソール開閉を兼ねる
- (おまけ)TextMeshProフォントの一括差し替え機能


# インストール

## 依存ライブラリ

- R3 https://github.com/Cysharp/R3.git?path=src/R3.Unity/Assets/R3.Unity
- IngameConsole(R3) https://github.com/sh-kj/Unity-IngameConsole.git?path=R3/IngameConsole
- SpriteDigits(R3) https://github.com/sh-kj/SpriteDigits.git?path=Unity-R3/SpriteDigits

以上ライブラリのPackageManagerへのインストールと、TextMeshProのセットアップを済ませてから  
Package Managerの`Install package from git URL` に https://github.com/sh-kj/Unity-IngameConsole.git を指定すればOKです。

# 使用法 

uGUIのCanvas下に、Prefabのどちらかを配置してください。  
また、IngameConsole側のドキュメントにもある通り `CommandInjector`による初期化も必要です。

## ショートカットボタン

`ShortcutButton` コンポーネントを `UnityEngine.UI.Button` と同一GameObjectに付け、
`Command Name` にボタンを押した時にコンソールに送りたいコマンドを書いておくことでショートカットボタンが作成できます。

## フォントの差し替え

このViewに限らず使えます。  

UnityEditorモードで `TMPFontReplacer` コンポーネントを任意のGameObjectに付け、
`Font Asset to replace:` にTextMeshProのFontAssetを指定して `Execute Replace` ボタンを押すと、付けたGameObjectの子すべての中の`Text Mesh Pro - Text`, `Text Mesh Pro - Input Field`のフォントが指定されたものに置き換えられます。

このPrefabではTextMeshProデフォルトのLiberationSans SDFが指定されているので日本語が表示できません。コンソールで日本語等を出したい場合はFontAsset作成後、この機能などを使って差し替えてください。