import React, { ReactElement, FC, ReactNode, useState, useEffect } from "react";
import {
    List,
    Datagrid,
    TextField,
    ListProps,
    EditButton,
    Edit,
    SimpleForm,
    TextInput,
    DateInput,
    Create,
    useDataProvider,
    Record,
    SingleFieldList,
    ChipField,
    ArrayField,
    DateField,
    NumberField,
    NumberInput,
    ArrayInput,
    SimpleFormIterator,
    SelectField,
    SelectInput,
} from "react-admin";

interface employeeProps {
    children?: ReactNode;
}

interface Cargos {
    id: number;
    inicio: Date;
    titulo: string;
}

interface Employee {
    id: number;
    nome: string;
    sobrenome: string;
    cpf: string;
    genero: string;
    dataNascimento: Date;
    dataContratacao: Date;
    cargos?: Array<Cargos>;
}

export const EmployeeIcon: FC = () => (
    <span
        className="iconify"
        data-icon="mdi:badge-account-horizontal"
        data-inline="false"
        data-width="30"
        data-height="30"
    ></span>
);

// export const EmployeeList: FC = (props) => {
//     return (
//         <List {...props} title="Funcionários">
//             <Datagrid rowClick="edit">
//                 <TextField source="id"></TextField>
//                 <TextField source="nome"></TextField>
//                 <TextField source="sobrenome"></TextField>
//                 <TextField source="cpf"></TextField>
//                 <TextField source="genero"></TextField>
//                 <DateField source="dataNascimento"></DateField>
//                 <DateField  source="dataContratacao" ></DateField>
//                 <EditButton basePath="/funcionarios" />
//                 <ArrayField source="cargos">
//                     <SingleFieldList>
//                         <ChipField source="titulo"  />
//                     </SingleFieldList>
//                 </ArrayField>
//             </Datagrid>
//         </List>
//     );
// };

export const EmployeeCreate: FC = (props) => (
    <Create title="Cadastrar um funcionário" {...props}>
        <SimpleForm>
            {/* <TextInput label="Número do Funcionário" disabled source="funcionarioNumero" /> */}
            <TextInput label="Nome" source="nome" />
            <TextInput label="Sobrenome" source="sobrenome" />
            <TextInput label="CPF" source="cpf" />
            <SelectInput
                source="genero"
                choices={[
                    { id: "H", name: "Feminino" },
                    { id: "M", name: "Masculino" },
                    { id: "M", name: "Mulher trans" },
                    { id: "M", name: "Homem trans" },
                ]}
            />
            {/* <TextInput label="Gênero" source="genero" /> */}
            <DateInput label="Data de Nascimento" source="dataNascimento" />
            <DateInput label="Data de contratação" source="dataContratacao" />
            <ArrayInput label="Cargos" source="cargos">
                <SimpleFormIterator>
                    {/* <NumberInput label="Número do Funcionário" source="funcionarioNumero" /> */}
                    <TextInput label="Título" source="titulo" />
                    <DateInput label="Início" source="inicio" />
                    <DateInput label="Término" source="termino" />
                </SimpleFormIterator>
            </ArrayInput>
        </SimpleForm>
    </Create>
);

export const EmployeeList: FC = (props) => {
    return (
        <List {...props}>
            <Datagrid rowClick="edit">
                {/* <TextField source="id" /> */}
                <NumberField
                    label="Número do Funcionário"
                    source="funcionarioNumero"
                />

                <TextField label="Nome" source="nome" />
                <TextField label="Sobrenome" source="sobrenome" />
                {/* <TextField label="Nome Social" source="sobrenome" /> */}
                <TextField label="CPF" source="cpf" />
                <DateField label="Data de Nascimento" source="dataNascimento" />
                <TextField label="Gênero" source="genero" />
                <DateField
                    label="Data de Contratação"
                    source="dataContratacao"
                />
                <ArrayField label="Cargos" source="cargos">
                    <SingleFieldList>
                        <ChipField source="titulo" />
                    </SingleFieldList>
                </ArrayField>
                {/* <TextField source="deparFuncs" /> */}
                {/* <TextField source="deparGerens" /> */}
                <ArrayField label="Salários" source="salarios">
                    <SingleFieldList>
                        <ChipField source="salario" />
                    </SingleFieldList>
                </ArrayField>
            </Datagrid>
        </List>
    );
};

const Title = (props: any) => {
    return (
        <span>
            {props.record
                ? `${props.record.nome} ${props.record.sobrenome}`
                : ""}
        </span>
    );
};

export const EmployeeEdit: FC = (props) => (
    <Edit {...props}>
        <SimpleForm>
            <NumberInput
                label="Número do Funcionário"
                disabled
                aria-disabled
                source="funcionarioNumero"
            />
            <TextInput label="Nome" source="nome" />
            <TextInput label="Sobrenome" source="sobrenome" />
            <TextInput label="CPF" source="cpf" />
            <DateInput label="Data de Nascimento" source="dataNascimento" />
            <TextInput label="Gênero" source="genero" />
            <DateInput label="Data de Contratação" source="dataContratacao" />
            <ArrayInput label="Cargos" source="cargos">
                <SimpleFormIterator>
                    {/* <NumberInput label="Número do Funcionário" source="funcionarioNumero" /> */}
                    <TextInput label="Título" source="titulo" />
                    <DateInput label="Início" source="inicio" />
                    <DateInput label="Término" source="termino" />
                </SimpleFormIterator>
            </ArrayInput>
            {/* <TextInput label="Nome" source="deparFuncs" />
            <TextInput label="Nome" source="deparGerens" />
            <TextInput label="Nome" source="salarios" /> */}
        </SimpleForm>
    </Edit>
);
