# Scriptable Variable Objects
 
## Installation
You can install this as a Package through Unity's PackageManager.
(Optionally) Use my Git Package Updater to install (& update) git packages: https://github.com/Toorah/com.toorah-games.gitupdater
 
## Generator
Included comes an Editor Window to quickly generate new *classes* for your own *types*.
It can be accessed via:
**`Window/Scriptable Variables/Generator`**

<img src="Documentation~/Screenshots/generator.png" width="900">
 
- By Default: There will be a List on the left, that includes the most used Unity Types to generate. These are also included by default to use without having to generate them. `Name` will be used as the Class Name, whereas `Type` is how to use the Type in script: `String`vs`string`, `Int`vs`int`, etc. Leaving the `Type` field empty will use the same as `Name`: `GameObject`vs`GameObject`
- Clicking the **`>`** button on the left, will preview that entry on the right panel.
- Clicking **`-`** button on the right, will remove an entry.
- Clicking **`Add`** will create a new empty entry
- The **Path** is where generated classes will be saved. Use the **Browse** button to select a folder within **Assets/**
- **Generate** will create 2 scripts in **Path**. One for the **Type** entered, and a specific **List\<T>** type

At the bottom-right of the Editor Window are 2 preview windows, to check the script file contents before they are generated.

## How to Use
To create Scriptbale Object Variables, go to:
**`Assets/Create/Scriptable Variables/*`**
Select the desired variable from either **`Single/`** or **`List/`**.

You can also create Container Objects that are useful for Grouping variables under a single Asset.
To create a Container Object, select:
**`Assets/Create/Scriptable Variables/Container`**

<img src="Documentation~/Screenshots/container_02.png" width="400">

In the **Inspector** you have the following features:
- At the top is the List of Variables that are created under this Asset
- **`Add new Variable`** allows to create a new Variable with the Type selected in the DropDown and the name of **`Variable Name`**. Once the type and name is set, click on **`Add`** to create a new Variable, it will be listed at the top.
- Selecting a Variable in the List, will display its inspector directly (alternatively, select the asset for the corresponding variable in your project window, under the container asset)

## Examples
> Inspectors for different Scriptable Object Variables</br>
Float Variable
<img src="Documentation~/Screenshots/float-var.png" width="300"><br>
Gradient Variable
<img src="Documentation~/Screenshots/gradient-var.png" width="300"><br>
GameObject List Variable
<img src="Documentation~/Screenshots/go-list-var.png" width="300"><br>

## Todo
- [x] Reference Class: Can be used with or without a variable object, to avoid having to create variable objects for everything, while allowing to use them anyway without changing the code
- [x] Property Drawers for Scriptable Variables
- [x] Better Generator Window
- [x] Containers: Group Variables
