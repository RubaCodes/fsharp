type RegisteredCustomer = { Id: string }
type UnregisteredCustomer = { Id: string }

type Customer =
    | Guest of Id: string
    | Eligible of Id: string
    | Registered of Id: string

let calculateTotal customer spend =
    let discount =
        match customer with
        | Eligible _ when spend >= 100.0M -> spend * 0.1M
        | _ -> 0.0M

    spend - discount

(*
    Expressions produce an output value. Pretty much everything in F# including values,
    functions, and control flows is an expression. This allows them to be easily composed.
*)
let john = Eligible "John"
let mary = Eligible "Mary"
let richard = Registered "Richard"
let sarah = Guest "Sarah"

// small example of validation using FSI highlight all code and ALT+ENTER
let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal richard 100.0M = 100.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M
