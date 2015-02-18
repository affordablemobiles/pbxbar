# PBXBar

PBXBar is a VB.NET desktop agent toolbar for use with GoAutoDial.

It allows agents to use GoAutoDial for Inbound and Outbound calls while staying pinned to their screen rather than having to keep track of a browser tab.

## Features

* Inbound calls via CLOSER campaigns.
* Outbound Calls (Manual Dial and DIAL NEXT from hopper).
* Auto "screen-pop" of a URL in the browser when a call comes in - URL specified from Asterisk variable for defining inside custom smart AGI IVR.
* Phone extension mapped to Windows PC name for config-less agent roaming.
* Colour coded "calls in queue" number indicator for Inbound Call queue.
* CefSharp (Embedded Chromium) used for "Call Script" tab.
* Pause Codes when set to "FORCE" in campaign.
* PCI DSS Compliant Start/Stop Call Recordings (Chrome Extension [here](https://github.com/infitialis/pbxbar-startstop-recording-pci))

## GoAutoDial

Designed to use the stock GoAutoDial AJAX calls for most things, getting started is as simple as pointing the toolbar to the agent login URL via the settings panel and a path to the phone mapping XML file.

## Internal Config

Some things have our internal config hard-coded - for things like internal extension validation on manual dials, etc.

Pull requests for a more generic, configurable way to handle these are welcome.

![screenshot of toolbar](https://raw.github.com/infitialis/pbxbar/master/docs/screenshots/1.%20Pre-Login%20Toolbar.png)
