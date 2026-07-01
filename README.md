# 💸 Project 25 — Tax Calculator Form

> First WinForms practice project in C# — a real-world tax calculation desktop app built using Form, Label, TextBox, and Button controls.

---

## 🚀 Project Overview

This is the **first external practice project** in C# after completing Course 14 (C# Level 1).

The approach:

Go back through every control covered in the course.

Build a real project using each control set before moving to the next.

This project covers the first set:

**Form → Labels → TextBoxes → Buttons**

The scenario is simple and real:

Imagine an accountant calculating VAT or a cashier computing the total after tax.

Enter the base amount.
Enter the tax rate as a percentage.
Get the tax amount and total — instantly.
Save the calculation to a session history.
Clear everything and start fresh.

That is exactly what this form does.

---

## 🏗️ Architecture Design

The project follows the same clean principles from Stage One — Divide & Conquer, single-responsibility functions — now applied inside a WinForms environment.

```
btnCalculate_Click
 └── IsAmountOrRatioEmpty()    ← guard: block if inputs are empty
      └── CalculateValues()
           ├── GetAmount()      ← reads Amount from TextBox
           ├── GetTaxRate()     ← converts % input to multiplier
           ├── GetTotalAmount() ← Amount × TaxRate
           └── GetTaxAmount()  ← Total − Amount

btnClear_Click
 ├── ClearTextBoxes()   ← UI layer: clears all TextBox controls
 └── ClearValues()      ← Data layer: resets all private fields to 0

btnSaveProcess_Click
 └── IsTextBoxesEmpty() ← guard: block if ANY field is empty
      └── Appends row to txtSavedHistory

btnDeleteAll_Click
 └── txtSavedHistory.Clear()
```

No function does more than one job.

No logic is duplicated.

---

## ⚙️ Core Functionalities

| Control | Action |
|---|---|
| `txtAmount` | User inputs the base amount |
| `txtTaxRate` | User inputs the tax rate as a percentage |
| **Calculate** | Computes Tax Amount and Total Amount |
| **Clear** | Resets all fields and internal values |
| **Save Process** | Appends the current calculation to session history |
| **Delete All** | Clears the full session history |
| `txtTaxAmount` | Read-only — displays calculated tax |
| `txtTotalAmount` | Read-only — displays total with tax |
| `txtSavedHistory` | Read-only multiline — scrollable calculation log |

---

## 🧠 Design Decisions Worth Noting

### Two-Layer Clear

Clear is split into two separate functions:

```csharp
private void ClearTextBoxes()  // UI layer — clears all visible controls
private void ClearValues()     // Data layer — resets all private fields
```

Both called from `btnClear_Click`.

This is the WinForms equivalent of separating UI from logic.

The UI can be reset independently of the data if needed.

---

### Percentage → Multiplier Conversion

`GetTaxRate()` converts the percentage input directly into a usable multiplier:

```csharp
private double GetTaxRate()
{
    return (Convert.ToDouble(txtTaxRate.Text.Trim()) / 100 + 1);
}
```

If the user enters `14`, this returns `1.14`.

Then `GetTotalAmount()` multiplies `Amount × TaxRate` and the result is already the full total.

One conversion. Zero extra steps.

---

### Layered Guard Functions

Two separate guard functions cover two different scenarios:

```csharp
private bool IsAmountOrRatioEmpty()      // used before Calculate
private bool IsTaxAmountOrTotalEmpty()   // combined into IsTextBoxesEmpty()
private bool IsTextBoxesEmpty()          // used before Save
```

You cannot calculate without inputs.

You cannot save without a completed result.

Each action is protected independently — no shared guard logic that blocks the wrong action.

---

## 🎯 What This Project Teaches

- Applying WinForms controls in a real scenario from scratch
- Separating UI logic from data logic inside event handlers
- Building guard functions before any user-triggered action
- Using read-only TextBoxes for output fields
- Multiline TextBox with scroll for session history
- Clean function design inside a WinForms project
- The Divide & Conquer principle applied in a GUI context

---

## 🛠️ Tech Stack

| | |
|---|---|
| **Language** | C# |
| **Framework** | .NET Framework |
| **UI** | Windows Forms (WinForms) |
| **IDE** | Visual Studio |
| **Type** | Desktop Application |
| **Controls Used** | Form, Label, TextBox, Button |

---

## 📦 Practice Project Series

This project is part of a self-directed WinForms practice series after Course 14.

The approach: master each control group through a dedicated real project.

| Project | Controls Practiced | Status |
|---|---|---|
| **Project 25 — Tax Calculator** *(you are here)* | Form, Label, TextBox, Button | ✅ |
| More projects | Next control groups | 🔄 |

---

## 🏁 Course & Milestone Context

- ✅ Course 14 — C# Level 1 complete (Stage Two begins)
- ✅ First C# desktop project after Stage One completion
- ✅ First project in the WinForms self-practice series
- ✅ Part of the **Programming Advices Roadmap** — Stage Two

---

## 🙏 Gratitude

Thank you to:

- **Programming Advices Platform**
- **Dr. Mohammed Abu-Hadhoud**

**[ https://programmingadvices.com ]**

For building a roadmap where the course is not the end.

The real work starts after.

---

## 🔥 What's Next

More controls.

More projects.

Each one stronger than the last.
