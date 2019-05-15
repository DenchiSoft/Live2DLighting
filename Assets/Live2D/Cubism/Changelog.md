## Live2D Cubism Unity Components Changelog

*2019-03-28*

- Added samples for Original Workflow.
- Fixed bugs in Original Workflow.


*2019-01-31*

- Added API to get the parent Part of the specified Part.
- Added API to get moc3 version.
- Added conponents for Original Workflow.


*2018-12-20*

- Upgrade Core version to 03.03.0000 (50528256). This upgrade is following Cubism Editor 3.3 features.
- [3.3] Support new Warp Deformer features.



*2018-08-22*

- Add the calculation method of Raycast.
- Synchronize drawing order and visibility setting with buffer swapping.


*2018-06-11*

- Update unmanaged module
- Update README.md.
- Improve behavior on importing SDK at first time
- Add animator component on importing model
- Fixed a bug to uncheck "Alpha Is Transparency" of the texture file used in the model when Unity was restarted.


*2018-02-06*

- Add missing user data code
- Refactoring renderer #12
- Avoid calculate Color*Opacity every time
- Reduce bandwidth
- Fix Typo in comment
- Fix rendering on transparency drawable


*2018-12-07*

- Fix unloading Moc resource
- Fix physics implements
- Improve physics
- Implement user data


*2017-10-12*

- Fix importing model without physics
- Fix memory alignment on allocation
- Fix opacity setting on initialization
- Replace hand-written bindings with https://github.com/Live2D/CubismBindings
- Remove redundant unsafe keyword
- Fix pulling paramater Ids from NativeCore
- Improve performance on mask rendering
- Fix pulling Ids from NativeCore
- Fix pulling minimum values from NativeCore
- Fix reimporting model


*2017-08-17*

- Implement physics
- Improve asset import/reimport
- Add auto-eye-blink component
- Add convenience array extension method
- Fix animation curve generation
- Fix calculating transform on masking rendering [#4](https://github.com/Live2D/CubismUnityComponents/issues/4)
- Update native plugin


*2017-07-12*

- Improve performance
- Add experimental WebGL support
- Fix mouth controller issue [#1](https://github.com/Live2D/CubismUnityComponents/issues/1)
- Fix inspectors issue [#3](https://github.com/Live2D/CubismUnityComponents/issues/3)
- Fix clipping issue [#4](https://github.com/Live2D/CubismUnityComponents/issues/4)
- Fix opacity issue [#5](https://github.com/Live2D/CubismUnityComponents/issues/5)
- Fix minor issues
- Merge shader optimization [#2](https://github.com/Live2D/CubismUnityComponents/pull/2)
- Restructure directory structure
- Update native plugin
