## NSolve Example


```mathematica
Clear["Global`*"];

(*Cost to buy a new car*)
C1 = 22000;
(*Cost for an accident*)
C2 = 2000;

(*car lifetime distribution*)
h[x_] = 1/10;
H[x_] = (x - 5)/10;
HC[x_] = (15 - x)/10;

(*overall cost*)
L[T_] = (C1 + C2*H[T])/(Integrate[x*h[x], {x, 5, T}] + T*HC[T]);
NSolve[L'[T] == 0 && T > 0, T, Reals]
Plot[L'[T], {T, -300, 100}, PlotRange -> Full]
```
