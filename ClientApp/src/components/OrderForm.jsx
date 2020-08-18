import React from 'react';
import { useForm } from 'react-form';
import $ from 'jquery';
import { TextField, Select } from './InputTypes';
import CountrySelect from './CountrySelect';

const titleSelectOptions = ['MR', 'MRS', 'MISS', 'MS', 'DOCTOR'];

const handleSubmit = async (values) => {
    console.log(values);
    await $.post('https://localhost:44329/api/order', values);
};

const OrderForm = () => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            handleSubmit(values);
        },
    });

    return (
        <div className="card m-3">
            <div className="card-body content-card">
                <div className="d-flex">
                    <Form>
                        <h3>Product Order Form</h3>
                        <p className="text-muted">Please input your details for the order.</p>
                        <hr />
                        <div>
                            <div className="form-row">
                                <Select
                                    field="title"
                                    options={titleSelectOptions}
                                    description="Select your title"
                                    defaultValue={titleSelectOptions[0]}
                                />
                            </div>
                            <div className="form-row">
                                <TextField name='firstName' placeholder='First Name' />
                            </div>
                            <div className="form-row">
                                <TextField name='lastName' placeholder='Last Name' />
                            </div>
                            <div className="form-row">
                                <TextField name='email' placeholder='Email Address' type="email" />
                            </div>
                            <div className="form-row">
                                <TextField name='phone' placeholder='Phone Number' />
                            </div>
                            <div className="form-row">
                                <TextField name='address1' placeholder='Address Line 1' />
                            </div>
                            <div className="form-row">
                                <TextField name='town' placeholder='Town' />
                            </div>
                            <div className="form-row">
                                <TextField name='postCode' placeholder='Post Code' />
                            </div>
                            <div className="form-row">
                                <CountrySelect />
                            </div>
                            <div className="form-row">
                                <TextField name='comments' placeholder='Comments' />
                            </div>
                            <div className="form-row">
                                <button className="btn btn-success btn-lg" type="submit">Order</button>
                            </div>
                        </div>
                    </Form>
                </div>
            </div>
        </div>
    );
};

export default OrderForm;