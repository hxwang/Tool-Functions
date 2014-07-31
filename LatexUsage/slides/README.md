Grammar of Beamer
=================

- References
* https://www.uncg.edu/cmp/reu/presentations/Charles%20Batts%20-%20Beamer%20Tutorial.pdf

### Frames
Each frame produces one or more slides, depending on the slide's overlay.

- Simple Frame

```
\begin{frame}[<alignment>]
\frametitle{Frame Title Goes Here}
  Frame body text and/or LATEX code
\end{frame}
```
`[<alignment>]` option: 
`c` means center; `t` means top; `b` means bottom

- Special Frame: table of contents

```
\begin{frame}
\frametitle{Outline}
\tableofcontents[part=1,pausesections]
\end{frame}
```
`pausesections` allows the speaker to talk about the first section before the second is shown when reading the table of contents.
