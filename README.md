# Project: Dream - B787 Full-Cockpit Flight Simulator

![image](https://user-images.githubusercontent.com/54985569/140247626-25ccd612-d31e-4a72-a9a7-1f879e0656f5.png)

Project: Dream was a long-term project undertaken by myself and two other people to build an entirely homemade (no COTS stuff) full-cockpit Boeing 787 Dreamliner flight simulator. This repo will serve as the free and open-source release point for that work, in hopes that it will help the flight sim community.

There was a tremendous amount of work done on the project, including (to my knowledge) significant design of components for which no CAD or drawings of any kind freely/openly exist. Here's a picture of the overhead panel assembly:

![image](https://user-images.githubusercontent.com/54985569/140246177-3dd7392e-5ed8-4090-8bb6-f011e104b773.png)

I will work to publish as much as I can over time, but this is an old project, and there will be limits to how much I remember and can provide. If anyone does come across this and needs more info, **please open an issue**, as I may be able to help you even if this repo does not have what you're looking for.

# Important Notes
All work was done with *PUBLICLY AVAILABLE INFORMATION*, and this is completely amateur, non-representative work that is IN NO WAY meant to simulate an actual Boeing 787. Any and all work contained herein is unsuitable for flight training.

# State of the project
I stopped working on this project in June 2019, at which point we had the cockpit frame built and interior finished (carpet, panelling, etc), projection screen built and working, MIP built with (at some point) working displays, linked yokes built and working (badly), throttles built and working (badly, motorization not working), korry switches built and working, and a bunch of panels - including overhead panels and the MCP - in progress.

So there was a huge amount left to finish, but life gets in the way, and COVID does as well.

# Info dump
- Intent is interoperation with the QualityWings 787 FSX/Prepar3D (787-9) + MobiFlight + FSUIPC.
- This is meant to be extremely cheap to build with commodity parts where possible
- Many things are really first-iteration designs and will certainly need tweaking to get them to be nice
- There was a lot of inexperience at play (this was high school)

### Design includes the following:

- full-cockpit frame (wood) with mostly faithful geometry
- wraparound continuous projection screen (3x short-throw projectors)
- signature 787 displays (5 total) in original form factor <3
  - laptop panels driven with external inverters
- overhead panel
  - three-layer stack, with two front layers and one rear structural layer
  - backlit (laser etches away paint on top panel); at least some design files complete
  - slightly curved like the real thing
- Illuminated Korry-style push switches
  - mechanical design + PCB
- Replicated 787 rotary knobs
  - 45deg switch sourcing
- Center pedestal
  - CCD with trackpad and buttons
  - Constructed from MDF, panel drawings available
  - Motorized throttles, belted and geared varieties (need work)
- MIP
  - design with the four displays (including actual sourcing for the displays and inverters, which work!)
  - Beginning of MCP panel with sourcing and code for the IAS, heading, V/S, and altitude displays (OLEDs)
  - _IAS display with QW787 in the background:_
  - ![image](https://user-images.githubusercontent.com/54985569/140248400-a0fd7e41-68d8-4185-a9d8-477a0d0697ce.png)
- Flight controls
  - Motorized throttles (not great though) mentioned above
  - Dual linked yokes (also not great), not motorized
  - 3D model for yokes themselves
  - No rudder pedals or tiller (these are not very aircraft-specific)
- Code and software
  - Small amount of shitty code available to drive the MCP displays, maybe some other miscellaneous stuff.
  - MobiFlight
  - FSX/Prepar3D
  - FSUIPC
  - Warpalizer (** Warpalizer sponsored us with a license and support)

### Intent for release schedule
I intend to release stuff in an organized way, but the original design files, information, and assets are not nearly organized enough for anyone else to make sense of them right now. So this will take some time, and it will be best-effort on my part.

# Licensing
This work is available strictly under GPLv3. See [LICENSE](https://github.com/dmezh/projectdream/blob/main/LICENSE) for more information.
