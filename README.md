# README #
**Floorplan** - tilebased level editor intended for use with 3D mesh based applications,  Unity3D 5.35


-----------------------------------
## - Development Notes - ##
### ***UvMapSector*** var of AssetObject BaseClasses - handled by TexturesViewerTexPreviewer.cs ###
* 0 - 15  = texture divided into 16 parts
* 20 - 23 = texture divided into 4 parts
* 30 = use the whole texture

* other values = notApplicable / NotImplemented

-----------------------------------
## TODO: ##
* toolbarUI
* eraser, duplicates at a Pos prevention
* map Tile[,] 2d array data basis
* undo/redo , with multiple steps
* removal of erased/ undone objects from Area lists

* save rooms and tiles to xml
* reconstruct in-game runtime .xml to GameObjects -- Convert GameObject, Material etc references to be String refs = which tranlate to lookup the Gameobject, Material etc
* AssetBundles ???

* **EntityToPaint Menu**
* determine what additional vars, etc.. each Entity Type requires , and the UI implementation for such vars
* entity functionalities
* determine proper Asset Categories enums ( AssetsViewerAssetManagement.cs )

* **POPULATE ASSETS / TEXATLAS LISTS**

-----------------------------------

* **- polish -**
* better assetPlacement drag painting
* draggable windows ??
* additional hotkeys 
* tutorials for users
* website links

* possibly, a playtest ability ?





-----------------------------------

* [Learn Markdown](https://bitbucket.org/tutorials/markdowndemo)