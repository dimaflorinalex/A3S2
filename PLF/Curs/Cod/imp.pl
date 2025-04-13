:- op(100, xf, {}).
:- op(1100, yfx, ;). % asoc la stg

aexp(I) :- integer(I).
aexp(X) :- atom(X).
aexp(A1 + A2) :- aexp(A1), aexp(A2).

bexp(true). bexp(false).
bexp(and(BE1, BE2)) :- bexp(BE1), bexp(BE2).
bexp(A1 =< A2) :- aexp(A1), aexp(A2).

stmt(while(BE, St)) :- bexp(BE), stmt(St).
stmt(skip).
stmt(X = AE) :- atom(X), aexp(AE).
stmt(St1;St2) :- stmt(St1), stmt(St2).
stmt(if(BE, St1, St2)) :- bexp(BE), stmt(St1), stmt(St2).

program(St, AE) :- stmt(St), aexp(AE).

test0 :- program( {x = 10 ; sum = 0;
                    while(0 =< x,
                        {sum = sum + x; x = x - 1}
                        )}
                    , sum).

get(S, X, I) :- member(vi(X, I),S).
get(_, _, 0).
set(S,X,I, [vi(X,I)|S1]) :- del(S, X, S1).

del([vi(X,_)|S],X,S).
del([H|S],X,[H|S1]) :- del(S,X,S1).
del([], _, []).

smallstepA(X,S,I,S) :-
    atom(X),
    get(S,X,I).

smallstepA(I1 + I2, S, I, S) :- 
    integer(I1), integer(I2),
    I is I1 + I2.

smallstepA(I + AE1, S, I + AE2, S) :-
    integer(I),
    smallstepA(AE1, S, AE2, S).

% smallstepA(AE1 + AE, S, AE2 + AE, S) :- ...

smallstepB(I1 =< I2, S, true, S) :-
    integer(I1), integer(I2),
    (I1 =< I2).
smallstepB(I1 =< I2, S, false, S):-
    integer(I1), integer(I2),
    (I1 > I2).

% smallstepB(I =< AE1, S, I =< AE2, S) :- ...
% smallstepB(AE1 =< AE2, S, AE2 =< AE, S) :- ...

smallstepB(not(true), S, false, S).
smallstepB(not(false), S, false, S).

% smallstepB(not(BE1), S, not(BE2), S) :- ...

smallstepS({E}, S, E, S).
smallstepS((skip;St2), S, St2, S).
% smallstepS((St1;St), S, (St2;St), S) :- ...

smallstepS(X = AE, S, skip, S1) :-
    integer(AE),
    set(S,X,AE,S1).

% smallstepS(X = AE1, S, X = AE2, S) :- ...

