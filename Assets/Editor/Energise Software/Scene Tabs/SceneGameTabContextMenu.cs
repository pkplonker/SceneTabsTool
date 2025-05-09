// Assets/Editor/MySceneToolbar.cs
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UIElements;

// 1) Register a toolbar element (a simple button)
[EditorToolbarElement(id, typeof(SceneView))]
class MySceneButton : EditorToolbarButton, IAccessContainerWindow
{
	public const string id = "MyCompany/SceneButton";

	// This property is set by the overlay system to the window in which the toolbar lives
	public EditorWindow containerWindow { get; set; }

	public MySceneButton()
	{
		text = "My Tool";
		tooltip = "Open My Custom Window";
		clicked += OnClick;
	}

	void OnClick()
	{
		// Show your custom window however you like
		MyCustomWindow.ShowWindow();
	}
}

// 2) Define the ToolbarOverlay that pulls in that element
[Overlay(typeof(SceneView), "My Scene Tools", true)]
[Icon("Packages/com.mycompany.mytool/icon.png")]    // optional icon
class MySceneToolbarOverlay : ToolbarOverlay
{
	// The base constructor takes the IDs of the toolbar elements you want to include
	public MySceneToolbarOverlay() : base(
		MySceneButton.id
		// you can list more IDs here if you add more elements
	) { }
}

// 3) Your custom window
public class MyCustomWindow : EditorWindow
{
	public static void ShowWindow()
		=> GetWindow<MyCustomWindow>("My Tool");

	void OnGUI()
	{
		GUILayout.Label("Hello from MyCustomWindow");
	}
}