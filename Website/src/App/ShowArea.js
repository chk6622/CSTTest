import React, { useContext, useEffect } from 'react';
import { Form, Input, Button } from 'antd';
import { AppContext } from './MyContext';
import { UPDATE_USER_INFORMATION } from './Actions';
import { Get, Post } from './HttpHelper';
import { isNullString } from './Tools';
import 'antd/dist/antd.css';

const formItemLayout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 16,
    },
};
const formTailLayout = {

    wrapperCol: {
        offset: 8,
        span: 16
    },
};


const ShowArea = () => {
    const [form] = Form.useForm();
    const { userInformation, dispatch } = useContext(AppContext);

    useEffect(() => {

        form.setFieldsValue({ FullName: userInformation.FullName });
        form.setFieldsValue({ PhoneNumber: userInformation.PhoneNumber });
        form.setFieldsValue({ Email: userInformation.Email });
        form.setFieldsValue({ VerificationCode: userInformation.VerificationCode });

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [userInformation.FullName, userInformation.PhoneNumber, userInformation.Email, userInformation.VerificationCode]);


    /**
     * Get a verification code 
     */
    const GetVerificationCode = () => {

        form.validateFields(['Email'])  //just validate Email field
            .then(curFormData => {

                const Email = curFormData.Email;
                const url = `UserInformation/getVerificationCode?email=${Email}`;

                Get(url).then(
                    ({ status, body }) => {
                        let message = '';
                        switch (status) {
                            case 200:
                                message = 'The verification code has been send to your email box.';
                                break;
                            case 400:
                                if (body.message === null) {
                                    let errors = body.errors;

                                    for (let key in errors) {
                                        message += `${errors[key]}`
                                    }

                                    if (isNullString(message)) {
                                        message = body.title;
                                    }
                                }
                                else {
                                    message = body.message;
                                }
                                if (isNullString(message)) {
                                    message = 'Request error!';
                                }
                                break;
                            case 500:
                                message = 'The website is being upgraded, please try again later.';
                                break;
                            default:
                                message = '';

                        }
                        if (!isNullString(message)) {
                            alert(message);
                        }
                    }
                );
            })
            .catch(
                errorInfo => {
                    // console.error(errorInfo);
                }
            );
    }

    /**
     * Submit the user information
     */
    const SubmitUserInformation = () => {

        form.validateFields()  //validate all fields
            .then(curFormData => {
                const submitData = {
                    FullName: curFormData.FullName,
                    PhoneNumber: curFormData.PhoneNumber,
                    Email: curFormData.Email,
                    VerificationCode: curFormData.VerificationCode
                }
                const url = 'UserInformation/AddUserInformation';

                Post(url, submitData).then(
                    ({ status, body }) => {
                        let message = '';
                        switch (status) {
                            case 201:
                                message = 'Submit successfully!';
                                break;
                            case 400:
                                if (body.message === null) {
                                    let errors = body.errors;

                                    for (let key in errors) {
                                        message += `${errors[key]}`
                                    }

                                    if (isNullString(message)) {
                                        message = body.title;
                                    }
                                }
                                else {
                                    message = body.message;
                                }
                                if (isNullString(message)) {
                                    message = 'Request error!';
                                }
                                break;
                            case 500:
                                message = 'The website is being upgraded, please try again later.';
                                break;
                            default:
                                message = '';
                        }
                        if (!isNullString(message)) {
                            alert(message);
                        }
                    }
                );
            })
            .catch(
                errorInfo => {
                    // console.error(errorInfo);
                }
            )
    }


    return (
        <Form form={form} style={{ width: '500px' }} name="UserInformation" layout="horizontal" size="large" onValuesChange={e => dispatch({ type: UPDATE_USER_INFORMATION, payload: e })}>
            <Form.Item
                {...formItemLayout}
                name="FullName"
                label="Full Name"
                rules={[
                    {
                        required: true,//submitType === SUBMIT_USER_INFORMATION,
                        max: 100
                    }
                ]}
            >
                <Input placeholder="Please input your full name" />
            </Form.Item>
            <Form.Item
                {...formItemLayout}
                name="PhoneNumber"
                label="Phone No"
                rules={[
                    {
                        max: 20
                    },
                ]}
            >
                <Input placeholder="Please input your phone number" />
            </Form.Item>
            <Form.Item
                {...formItemLayout}
                name="Email"
                label="Email"
                rules={[
                    {
                        required: true,
                        type: 'email',
                        max: 100
                    }
                ]}
            >
                <Input placeholder="Please input your email" />
            </Form.Item>
            <Form.Item
                {...formItemLayout}
                name="VerificationCode"
                label="Email Verification Code"
                rules={[
                    {
                        required: true,//submitType === SUBMIT_USER_INFORMATION,
                        max: 10
                    },
                ]}
            >
                <Input placeholder="Please input your verification code" />
            </Form.Item>

            <Form.Item {...formTailLayout}>
                <Button type="primary" onClick={() => SubmitUserInformation()}>
                    Submit
                </Button>
                <Button type="button" style={{ margin: '0 16px' }} onClick={() => GetVerificationCode()}>
                    Send Verification Code
                </Button>
            </Form.Item>
        </Form >
    )
}

export default ShowArea;