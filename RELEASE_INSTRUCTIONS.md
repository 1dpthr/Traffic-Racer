# How to Create a GitHub Release for Traffic Racer

## Prerequisites

1. **Unity Editor** installed on your machine
2. **GitHub account** with access to the repository
3. Built game files (executable for your target platform)

## Step 1: Build the Game

### For Windows:
1. Open the project in Unity Editor
2. Go to **File > Build Settings**
3. Select **Windows** as the target platform
4. Click **Switch Platform** if needed
5. Click **Build And Run**
6. Choose a location to save the build (e.g., `Builds/Windows/TrafficRacer.exe`)

### For Mac:
1. Open the project in Unity Editor
2. Go to **File > Build Settings**
3. Select **Mac** as the target platform
4. Click **Switch Platform** if needed
5. Click **Build And Run**
6. Choose a location to save the build

### For Android:
1. Open the project in Unity Editor
2. Go to **File > Build Settings**
3. Select **Android** as the target platform
4. Configure Player Settings (Company Name, Product Name, icons, etc.)
5. Click **Build And Run** or **Build**
6. This will generate an `.apk` or `.aab` file

## Step 2: Create a Release on GitHub

### Option A: Using GitHub Website (Recommended)

1. Go to your repository: https://github.com/1dpthr/Traffic-Racer
2. Click on **Releases** (right side of the page)
3. Click **Draft a new release**
4. Fill in the release details:

   - **Choose a tag**: Create a new tag (e.g., `v1.0.0`)
   - **Release title**: e.g., "Traffic Racer v1.0.0 - Initial Release"
   - **Description**: Add release notes (see template below)

5. **Attach build files**:
   - Drag and drop your built game files
   - Or click "Attach binaries" and select the files
   - Common files to upload:
     - `TrafficRacer.exe` (Windows)
     - `TrafficRacer.app` (Mac)
     - `TrafficRacer.apk` (Android)

6. Click **Publish release**

### Option B: Using GitHub CLI (if installed)

```bash
# Install GitHub CLI first (if not installed)
# Then run:

cd "/path/to/your/build/folder"

# Create a release with assets
gh release create v1.0.0 \
  --repo 1dpthr/Traffic-Racer \
  --title "Traffic Racer v1.0.0 - Initial Release" \
  --notes "Initial release of Traffic Racer game" \
  TrafficRacer.exe
```

## Release Notes Template

```markdown
## 🎮 Traffic Racer v1.0.0

### Features
- Endless traffic racing gameplay
- Multiple car models to choose from
- Dynamic traffic system
- Score tracking system
- Garage car selection
- Smooth camera controls

### Controls
- **W/Up Arrow**: Accelerate
- **S/Down Arrow**: Brake/Reverse
- **A/Left Arrow**: Move Left
- **D/Right Arrow**: Move Right

### System Requirements
- **Windows**: Windows 7/8/10/11
- **Mac**: macOS 10.12 or later
- **Android**: Android 5.0 or later

### Known Issues
- None currently reported

### Credits
Built with Unity Game Engine
```

## Step 3: Update Repository Description

After creating the release, you can update your repository description on GitHub:

1. Go to your repository: https://github.com/1dpthr/Traffic-Racer
2. Click the gear icon (Settings) near "About"
3. Add a description: "A 3D traffic racing game built with Unity"
4. Add website link (if you have one)
5. Add topics: `unity`, `game`, `traffic-racer`, `csharp`, `3d-game`

## Tips

- **File Size**: GitHub has a 100MB file size limit per file. For larger files, consider using Git LFS or splitting the build.
- **Compression**: Compress your build files (ZIP, RAR, 7z) to reduce upload size
- **Multiple Platforms**: You can create separate releases for different platforms or include all in one release
- **Version Numbering**: Use semantic versioning (e.g., v1.0.0, v1.1.0, v2.0.0)

## Troubleshooting

### "Unity not found" error
- Make sure Unity Hub and Unity Editor are installed
- Add Unity to your system PATH if needed

### "Build failed" error
- Check the Unity Console for errors
- Make sure all required assets are imported
- Verify that all scripts compile without errors

### "Upload failed" on GitHub
- Check file size (must be under 100MB)
- Try compressing the file
- Ensure you have stable internet connection

## Next Steps

After creating your first release:
1. Share the release link with others
2. Gather feedback
3. Plan updates and new features
4. Create new releases as you update the game

---

**Need Help?**
- Unity Documentation: https://docs.unity3d.com/
- GitHub Releases Guide: https://docs.github.com/en/repositories/releasing-projects-on-github