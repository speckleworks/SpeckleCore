# SpeckleCore
[![Build status](https://ci.appveyor.com/api/projects/status/k0n0853v26f1thl4/branch/master?svg=true)](https://ci.appveyor.com/project/SpeckleWorks/specklecore/branch/master) [![DOI](https://zenodo.org/badge/100398062.svg)](https://zenodo.org/badge/latestdoi/100398062)

## Overview

This is the core .NET client lib of Speckle. It provides: 
- async methods for calling the speckle [api](https://speckleworks.github.io/SpeckleOpenApi/) 
- methods for interacting with the speckle's websocket api
- the core conversion methods (`Serialise` and `Deserialise`) & other helper methods
- a base SpeckleObject from which you can inherit to create your own speckle kits

Pretty much all of speckle's connectors are using this library, including:
- Rhino
- Grasshopper
- Revit
- Dynamo
- Unity (with flavours)

## Example usage

Please check [out the docs and sample starter project on the speckle website](https://speckle.systems/docs/developers/dotnet-sdk)!

## License 
MIT
