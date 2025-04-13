% Model - Test de laborator 
% 
% Exemple de subiecte
% ATENTIE! Structura testului final nu va fi ca in model, aici aveti doar exercitii de antrenament

% Exercitiul 1 - Rezolvat
% Fie un predicat employee_salary/2 care configureaza un nume de angajat si salariul acestuia.
% De exemplu, employee_salary(peter, 1000)
% Primind o lista de elemente employee_salary, determinati numele tuturor angajatilor care castiga o suma minima configurata.
% veti scrie un predicat employee_with_good_salary(InputList, MinimumSalary, ResultList).
% de exemplu
% ?- employee_with_good_salary([employee_salary(peter, 1000), employee_salary(oliver, 1200), employee_salary(sam, 700), employee_salary(ben, 15000), employee_salary(sandra, 4500)], 1200, Res).
% Res = [oliver, ben, sandra]

employee_with_good_salary(InputList, MinimumSalary, ResultList) :-
    findall(Name, (member(employee_salary(Name, Salary), InputList), Salary >= MinimumSalary), ResultList).

% Exercitiul 2 - To do
% Primind o lista identica celei de la exercitiul 1, dar cu aparitii multiple ale unui angajat, 
% 	(considerand ca fiecare intrare reprezinta salariul intr-o anumita luna)
% 	determinati salariul mediu al fiecarui angajat. 
% de exemplu, daca peter apare (peter, 1000), respectiv (peter, 1200), in lista de rezultat va fi doar (peter, 1100)
% ?- employee_average_salary([(peter, 1000), (oliver, 1200), (sam, 700), (oliver, 800), (sam, 900), (sandra, 4500), (peter, 1200), (oliver, 400)], Result).
% Result = [(peter, 1100), (oliver, 800), (sam, 800), (sandra, 4500)]

% Exercitiul 3 - To do
% Primind o lista identica celei de la exercitiul 2, in lista de rezultat ordonati angajatii dupa salariul mediu castigat, in ordine descrescatoare. 
% ?- sort_employee_average_salary([(peter, 1000), (oliver, 1200), (sam, 700), (oliver, 800), (sam, 900), (sandra, 4500), (peter, 1200), (oliver, 400)], Result).
% Result = [(sandra, 4500), (peter, 1100), (oliver, 800), (sam, 800)]

% Exercitiul 4 - Dutch Royal Family - Rezolvat

mother(wilhelmina,juliana).
mother(juliana,beatrix).
mother(juliana,christina).
mother(juliana,irene).
mother(juliana,margriet).
mother(beatrix,friso).
mother(beatrix,alexander).
mother(beatrix,constantijn).
mother(emma,wilhelmina).
father(hendrik,juliana).
father(bernard,beatrix).
father(bernard,christina).
father(bernard,irene).
father(bernard,margriet).
father(claus,friso).
father(claus,alexander).
father(claus,constantijn).
father(willem,wilhelmina).

% citim mother(beatrix, alexander) ca "beatrix este mama lui alexander". aceeasi interpretare la father 

queen(beatrix).
queen(juliana).
queen(wilhelmina).
queen(emma).
king(willem).

% 4a) definiti urmatoarele predicate
% parent/2 - parent(X, Y). sa fie true cand X este parinte al lui Y 
% ruler(X) - sa fie true cand X este conducator 

parent(X, Y) :- mother(X, Y).
parent(X, Y) :- father(X, Y).

ruler(X) :- queen(X).
ruler(X) :- king(X).

% 4b) definiti un predicat predecessor/2, astfel incat predecessor(X, Y) sa ne spuna ierarhia de predecesori pentru un conducator X
% (vrem sa raspundem, de fapt, la cine precede pe cine)

predecessor(X, Y) :- ruler(X), ruler(Y), parent(Y, X).
predecessor(X, Y) :- ruler(X), ruler(Z), parent(Z, X), predecessor(Z, Y).

% Exercitiul 5 - Rezolvat
% Fie L = (R, F, C, ari) o structura de ordinul I, unde F = {f, g, h}, C = {u, v, w} iar ari(f) = 2, ari(g) = 1, ari(h) = 3
% Considerand a, b, c, d variabile, care dintre urmatorii termeni se pot unifica?
% a) f(g(a), h(b, c, v)) cu f(g(u), h(g(w), w, g(a)))
% b) f(g(a), h(b, c, d)) cu f(g(u), h(g(w), w, g(a)))

% se va scrie in terminal
% ?- unify_with_occurs_check(f(g(A), h(B, C, v)), f(g(u), h(g(w), w, g(A)))).
% raspunsul este false, pentru ca termenii nu unifica. v/0 iar g/1, se va incerca unificarea v = g(A) => esec 

% ?- unify_with_occurs_check(f(g(A), h(B, C, D)), f(g(u), h(g(w), w, g(A)))).
% raspunde A = u, B = g(w), C = w, D = g(u)

% Exercitiul 6 - To do
% Fie predicatele succ/2 si obj/1 (pentru succesor si obiectiv din BFS). 
% Adaptati algoritmul BFS astfel incat sa pastram drumurile cele mai scurte care ajung de la un nod de start la un nod obiectiv. 

% Exercitiul 7 - Rezolvat
% verificati daca un sir de caractere primit ca intrare, si reprezentat ca un atom, este palindrom sa nu
% palindrome(prolog). atunci false
% palindrome(ele). atunci true 

palindrome(Str) :-
    string_chars(Str, ListChars),
    reverse(ListChars, ReversedList),
    ListChars == ReversedList.

% Exercitiul 8 - Rezolvat
% Fie urmatoarea baza de cunostinte, definita de predicatele 
% 	employee_info(name, department_number, scale)
%	department(department_number, department_name)
%	salary(scale, amount)

employee_info(mcardon,1,5).
employee_info(treeman,2,3).
employee_info(chapman,1,2).
employee_info(claessen,4,1).
employee_info(petersen,5,8).
employee_info(cohn,1,7).
employee_info(duffy,1,9).
department(1,board).
department(2,human_resources).
department(3,production).
department(4,technical_services).
department(5,administration).
salary(1,1000).
salary(2,1500).
salary(3,2000).
salary(4,2500).
salary(5,3000).
salary(6,3500).
salary(7,4000).
salary(8,4500).
salary(9,5000).

% a) determinati toti angajatii din departamentul 1 si care au scale > 2 
% Exemplu pentru rezolvare
% ?- employee_info(Name, Department_Number, Scale), Department_Number = 1, Scale > 2 
% acum, puneti toate aceste rezultate intr-o singura lista 

employees_from_department_eq_1_with_scale_gt_2(List) :-
    findall(Name, (employee_info(Name, Department_Number, Scale), Department_Number = 1, Scale > 2), List).

% b) determinati toti angajatii dintr-un anume departament 

employees_from_department(DepNumber, List) :-
    findall(Name, (employee_info(Name, Department_Number, _), Department_Number = DepNumber), List).

% c) selectati name si scale al angajatilor din departamentul 1, si scale > 3 

employees_name_scale_from_department_eq_1_with_scale_gt_3(List) :-
    findall((Name, Scale), (employee_info(Name, Department_Number, Scale), Department_Number = 1, Scale > 3), List).