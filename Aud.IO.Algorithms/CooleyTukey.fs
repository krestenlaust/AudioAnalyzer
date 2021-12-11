namespace Aud.IO.Algorithms

open System
open System.Numerics

module CooleyTukey =
    let splitArray array = Array.foldBack (fun x (l, r) -> x::r, l) array ([],[])

    let rec forwardComputations (amplitudes : Complex array) =
        let N = amplitudes.Length

        if N <= 1 then
            amplitudes
        else
            let (even, odd) = splitArray(amplitudes)

            let evenArray = forwardComputations (even |> Array.ofList)
            let oddArray = forwardComputations (odd |> Array.ofList)

            for k in 0..N/2-1 do
                let w = exp(Complex(0.0, -2.0 * Math.PI * float k / float N))
                amplitudes.[k] <- evenArray.[k] + w * oddArray.[k]
                amplitudes.[N/2 + k] <- evenArray.[k] - w * oddArray.[k]

            amplitudes


    let Forward (amplitudes : float array) =
        //let window = 1.0
        let N = amplitudes.Length
        let window k = Math.Sin(Math.PI * (float k + 0.5) / float N) ** 2.0
        let x = [| for k in 0..N-1 -> Complex(amplitudes.[k] * window(k), 0.0) |]

        forwardComputations x

    let rec backwardComputations (freqeuncy : Complex array) =
        let N = freqeuncy.Length

        if N = 1 then
            freqeuncy
        else
            let (even, odd) = splitArray(freqeuncy)

            let evenArray = forwardComputations (even |> Array.ofList)
            let oddArray = forwardComputations (odd |> Array.ofList)

            for k in 0..N/2-1 do
                let w = exp(Complex(0.0, 2.0 * Math.PI * float k / float N))
                freqeuncy.[k] <- (evenArray.[k] + w * oddArray.[k]) / Complex(double N, 0.0)
                freqeuncy.[N/2 + k] <- (evenArray.[k] - w * oddArray.[k]) / Complex(double N, 0.0)

            freqeuncy