# zicat
Catalog software for box-based storage systems.

What does that mean? Basically, if you had alot of stuff, you would organize them into seperate boxes.

zicat catalogs these boxes and lets you search for an item, such as a spare ram stick, and then zicat will tell you which box that item is in.

This is the Win32 branch. It is designed to run on a lightweight version of Windows, for example, <a href="https://winksplorer.net/software/10Lv1-x64.iso">10L</a>.

# How to download & build
Win32 branch is designed to be built on linux.

On Linux, just run this command:
`git clone --branch win32 https://github.com/z-izz/zicat`

Then cd into the newly created zicat folder.
`cd zicat`

Then build.
`make build`

# How to add listings
zicat uses a zicat.db file in your home folder. For example: `C:\Users\billg\zicat.db`

The zicat.db file uses a modified version of the .INI file format. <a href="https://youtu.be/3Y84N0ny8wM">This 3-minute video</a> should explain INI for you. Although zicat's INI format is a bit different.

Here's a quick template, Although zicat auto-generates this template on first run.

```ini
[pcparts]
ram-ddr4-8gb
ram-ddr4-8gb
sata-hdd
[cables]
micro-usb
micro-usb
usb-c
usb-c
usb-c
```
