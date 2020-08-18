import React from 'react';
import { useField, splitFormProps } from 'react-form';

export const TextField = ({ name, placeholder, type }) => {
    const { getInputProps } = useField(name);
    return (
        <input {...getInputProps()} type={type ? type : 'text'} className='form-control' placeholder={placeholder} />
    );
};

export const Select = (props) => {
    const [field, fieldOptions, { description, defaultValue, handleQuestionSelectChange, options, ...rest }] = splitFormProps(props);

    const {
        value = defaultValue,
        setValue
    } = useField(field, fieldOptions);

    const handleSelectChange = (event) => {
        setValue(event.target.value);
        handleQuestionSelectChange && handleQuestionSelectChange(event.target.value);
    };

    return (
        <select {...rest} className='custom-select' value={value} onChange={handleSelectChange}>
            <option disabled value={null} >--{description}--</option>
            {options.map(o => (
                <option key={o} value={o}>{o}</option>
            ))}
        </select>
    );
};