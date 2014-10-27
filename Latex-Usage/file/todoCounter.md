## TODO Counter

### Code
Add the following code before `\begin{document}`
```
\usepackage{color}
\newcounter{todocounter}
\newcommand{\todo}[1]{\stepcounter{todocounter}\textcolor{red}{to-do\#\arabic{todocounter}: #1}}
```


### Usage
- `\todo{the todo items}`
