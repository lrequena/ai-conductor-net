## Custom Plugins

This folder is intended for storing custom DLLs that contain either your own or third-party's custom Agents, Tasks, etc. These DLLs should adhere to the naming convention specified below and be placed in the `Plugins` folder.

### Naming Convention

Custom DLLs should follow the naming convention: `AIConductor.ThirdParty.*.dll`. For example, a custom Agent DLL could be named `AIConductor.ThirdParty.MyCustomAgent.dll`, and a custom Task DLL could be named `AIConductor.ThirdParty.MyCustomTask.dll`, etc.

If you wish to include your company name or author name, you can do so by extending the convention, such as: `AIConductor.ThirdParty.MyCompany.MyCustomAgent.dll`, `AIConductor.ThirdParty.MyName.MyCustomTask.dll`, etc.