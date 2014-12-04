## Appendix


### Mode 1
- [Ref](http://tex.stackexchange.com/questions/132972/how-to-force-latex-to-change-from-a-appendixs-name-to-appendix-a)
- use package: `\usepackage[titletoc,title]{appendix}`
- code
``` latex
\begin{appendices}
\section{nameA}
    blablabla
\section{}
    blablabla
\end{appendices}
```

- effect
``` latex
Appendix A nameA
blablabla
Appendix B 
blablabla
```

### Mode 2
- It seems Mode 1 only works in `article` or `book` format, for IEEE two column template, I use this [approach](http://tex.stackexchange.com/questions/97370/numbering-of-subsections-in-the-appendix)
- code
``` latex
\appendix
\section*{Appendix}
\renewcommand{\thesubsection}{\Alph{subsection}}

\subsection{Appendix Subsection}
\lipsum[2]

\subsection{Another appendix Subsection}
\lipsum[3]  
```
- effect
```
Appendix 
A. xxx
B. xxx
C. xxx
```
