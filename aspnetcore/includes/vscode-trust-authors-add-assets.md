* Visual Studio Code displays a dialog box that asks: **Do you trust the authors of the files in this folder?**. Select:
  * The checkbox **trust the authors of all files in the parent folder**.
  * **Yes, I trust the authors** (because dotnet generated the files).

* Visual Studio Code requests that you add assets to build and debug the project, select **Yes**. If Visual Studio Code doesn't offer to add build and debug assets, select **View** > **Command Palette** and type "`.NET`" into the search box. From the list of commands, select the `.NET: Generate Assets for Build and Debug` command.

  Visual Studio Code adds a `.vscode` folder with generated `launch.json` and `tasks.json` files.