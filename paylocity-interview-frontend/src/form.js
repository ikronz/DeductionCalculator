import React from 'react';
import './form.css';

class DeductionForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            dependent: '',
            dependentsArr: [],
            showResponse: false,
            responseData: []
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleArrayChange = this.handleArrayChange.bind(this);
    }

    handleChange(event) {
        this.setState({
            ...this.state,
            [event.target.name]: event.target.value
        });
    }

    handleArrayChange() {
        this.setState({
            ...this.state,
            dependentsArr: [...this.state.dependentsArr, this.state.dependent],
            dependent: ''
        });
    }

    handleSubmit(event) {
        fetch('https://localhost:44360/api/Deductibles', {
            method: 'post',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "name": this.state.name,
                "dependents": this.state.dependentsArr
            })
        }).then(function (response) {
            return response.json();
        }).then(data => 
            this.setState({
                ...this.state,
                responseData: data,
                showResponse: true
            })
        );
        event.preventDefault();
    }

    render() {
        return (
            <div className="app">
                <h1>Paylocity Interview Deduction App</h1>
                <header className="app-header">
                    <form onSubmit={this.handleSubmit}>
                        <label>Name</label>
                        <br></br>
                        <input name="name" type="text" value={this.state.name} onChange={this.handleChange} />
                        <br></br>
                        <label>Dependent</label>
                        <br></br>
                        <input name="dependent" type="text" value={this.state.dependent} onChange={this.handleChange} />
                        <button type="button" onClick={this.handleArrayChange}>Add dependent</button>
                        <br></br>
                        { this.state.dependentsArr.map(d => <p style={{ fontSize: 13 }}>{d}</p>) }
                        <input type="submit" value="Submit for Deduction" />
                    </form>
                    <div>
                        {this.state.showResponse &&
                        <>
                            <p>Total yearly deduction is: ${this.state.responseData.deductionYearly.toLocaleString()}</p>
                            <p>Amount deducted per paycheck: ${this.state.responseData.deductionPerPaycheck.toLocaleString()}</p> 
                            <p>Total yearly pay after deduction: ${this.state.responseData.payAfterDeductionYearly.toLocaleString()}</p>
                            <p>Total paycheck post-deduction: ${this.state.responseData.payAfterDeductionPerPaycheck.toLocaleString()}</p>
                        </>
                        }
                    </div>
                </header>
            </div>
        );
    }
}

export default DeductionForm;