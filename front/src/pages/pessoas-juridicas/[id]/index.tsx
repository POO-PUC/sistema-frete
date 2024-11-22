import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { PessoaJuridicaContext } from '../../../contexts/PessoaJuridicaContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';
import { toast } from 'react-toastify';

const EditPessoaJuridica = () => {
  const { pessoasJuridicas, updatePessoaJuridica } = useContext(PessoaJuridicaContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [razaoSocial, setRazaoSocial] = useState('');
  const [inscricaoEstadual, setInscricaoEstadual] = useState('');
  const [cnpj, setCnpj] = useState('');
  const [endereco, setEndereco] = useState('');
  const [telefone, setTelefone] = useState('');
  const [dataDeInscricao, setDataDeInscricao] = useState('');
  const [ehRepresentante, setEhRepresentante] = useState(false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const pessoaJuridica = pessoasJuridicas.find((pj) => pj.codigo === Number(id));
    if (pessoaJuridica) {
      setRazaoSocial(pessoaJuridica.razaoSocial);
      setInscricaoEstadual(pessoaJuridica.inscricaoEstadual);
      setCnpj(pessoaJuridica.cnpj);
      setEhRepresentante(pessoaJuridica.ehRepresentante);
    }
  }, [id, pessoasJuridicas]);

  const handleUpdatePessoaJuridica = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updatePessoaJuridica(Number(id), {
        razaoSocial,
        inscricaoEstadual,
        cnpj,
        ehRepresentante,
      });

      toast.success('Pessoa Jurídica atualizada com sucesso!');
      router.push('/pessoas-juridicas');
    } catch (error) {
      console.error('Erro ao atualizar pessoa jurídica:', error);
      toast.error('Erro ao atualizar pessoa jurídica.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.editPessoaJuridicaContainer}>
        <h1>Editar Pessoa Jurídica</h1>
        <form onSubmit={handleUpdatePessoaJuridica} className={styles.form}>
          <div className={styles.formGroup}>
            <label htmlFor="razaoSocial">Razão Social</label>
            <input
              id="razaoSocial"
              type="text"
              value={razaoSocial}
              onChange={(e) => setRazaoSocial(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="inscricaoEstadual">Inscrição Estadual</label>
            <input
              id="inscricaoEstadual"
              type="text"
              value={inscricaoEstadual}
              onChange={(e) => setInscricaoEstadual(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="cnpj">CNPJ</label>
            <input
              id="cnpj"
              type="text"
              value={cnpj}
              onChange={(e) => setCnpj(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="ehRepresentante">
              <input
                id="ehRepresentante"
                type="checkbox"
                checked={ehRepresentante}
                onChange={(e) => setEhRepresentante(e.target.checked)}
              />
              É Representante
            </label>
          </div>

          <Button type="submit" loading={loading}>
            Atualizar Pessoa Jurídica
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default EditPessoaJuridica;
