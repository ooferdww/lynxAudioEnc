# lynxAudioEnc

A simple audio encoding GUI with parallel multithreading written in C# .NET WinForms. Powered by FFmpeg and TagLibSharp.

## Supported Encoders

* **QAAC** (AAC encoder, *not included*) — by nu774, Apple
* **FDK AAC** (AAC encoder, *not included*) — by Fraunhofer
* **vac-enc** (Opus frontend based on `opus-tools`, *included*) — by 6ws, gianni-rosato
* **oggenc** (Vorbis encoder, *included*) — by Xiph.Org
* **FhG MP3 v3.01** (MP3 encoder, *not included*) — by Fraunhofer
* **LAME** (MP3 encoder, *included*) — by The LAME Team

---

## Installing Optional Encoders

3 of the supported encoders are not included in the release download due to licensing constraints. Instructions to manually install them are as follows:

### QAAC
1. Download **QAAC** from [nu774's repository](https://github.com/nu774/qaac).
2. Download the **QAAC support files** from QTFiles repository.
3. Extract the contents of both archives into the same directory.
4. Copy the contents of this directory (ensuring `qaac64.exe` is present) into:
   `lynxAudioEnc/Data/qaac`

### FDK AAC
1. Obtain a build of `fdkaac.exe` from a trusted source.
2. Copy `fdkaac.exe` into:
   `lynxAudioEnc/Data/fdkaac`

### FhG MP3 v3.01
1. Obtain a copy of the encoder from wherever. (must include `mp3enc.exe`).
2. Copy `mp3enc.exe` and other nearby files into:
   `lynxAudioEnc/Data/mp3enc301`

---

> **Note on Updating Included Encoders:**  
> The pre-included binaries (`vac-enc`, `oggenc`, `lame`) can be manually updated at any time by replacing the executable files in their respective `Data` subfolders.
