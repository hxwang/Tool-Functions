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