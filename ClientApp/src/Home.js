import React from 'react';
import { useForm } from 'react-form';
import $ from 'jquery';

const handleSubmit = async (values) => {
    console.log(values);
    await $.post("https://localhost:44329/api/order", values);
    // var s = await $.get("https://localhost:44329/api/countries");
    // console.log(s);

};

const Home = () => {
    const { Form } = useForm({
        onSubmit: async (values) => {
            handleSubmit(values)
        },
    });


    return (
        <Form>
            <button className="btn btn-success btn-sm" type="submit">lol</button>
        </Form>
    );

}

export default Home;
