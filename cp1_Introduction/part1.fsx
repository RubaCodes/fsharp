(* 
    defines a type with a nuple that has string,bool,bool

type Customer = string * bool * bool // tuple with no named value
let fred: Customer = ("Fred", true, true) // explicit type binding
let (id, isEligibile, isRegistered) = fred // n-uple destucturing
*)

type Customer =
    { Id: string
      IsEligible: bool
      IsRegistered: bool }

(*
//Able to infer type because there's only one type defined in the structure
let fred =
    { Id = "Fred"
      isEligibile = true
      isRegistered = true }
*)


//the type after the last arrow is the return type, scopes are defined by indentation (whitespace)
//you can pass the parameters also in a form of a tuple (customer: Customer, spend: decimal) Customer * spend -> decimal

(*
let calculateTotal (customer: Customer) (spend: decimal) : decimal =
    let discount =
        if customer.isEligibile && spend >= 100.0M then
            spend * 0.1M
        else
            0.0M

    let total = spend - discount
    total // no return keyword
*)
// with type inference

let calculateTotal customer spend =
    let discount =
        if customer.IsEligible && spend >= 100.0M then
            spend * 0.1M
        else
            0.0M

    spend - discount

let john =
    { Id = "John"
      IsEligible = true
      IsRegistered = true }

let mary =
    { Id = "Mary"
      IsEligible = true
      IsRegistered = true }

let richard =
    { Id = "Richard"
      IsEligible = false
      IsRegistered = true }

let sarah =
    { Id = "Sarah"
      IsEligible = false
      IsRegistered = false }


// small example of validation using FSI highlight all code and ALT+ENTER
let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal richard 100.0M = 100.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M

//There is no such thing as == or even === in F#. We use = for binding, setting property
//values, and equality. To update mutable bindings, we use the <- operator:
//let mutable myInt = 0
//myInt = 1 // false [equality check]
//myInt <- 1 // myInt = 1 [assignment]
//myInt = 1 // true
//Notice that we have to explicitly define a binding as mutable.
