import React, { useState, useEffect } from 'react';
import { Select } from './InputTypes';
import $ from 'jquery';

const CountrySelect = () => {
    const [countries, setCountries] = useState([]);

    useEffect(() => {
        const getCountries = async () => {
            const response = await $.get('https://localhost:44329/api/countries');
            setCountries(response);
        };
        getCountries();
    });

    return (
        <Select
            field="country"
            options={countries}
            description="Select your Country"
            defaultValue={countries ? countries[0] : ''}
        />
    );
};

export default CountrySelect;